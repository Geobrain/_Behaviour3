using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public static class HelperBehaviors
{
  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static bool IsAnyBehaviorsWorked(this Ent e, List<string> behaviorNames)
  {
    var cBehaviors = e.ComponentBehaviors();
    if (cBehaviors.activeBehavior == null) return false;
    foreach (var behavior in behaviorNames)
    {
      if (behavior == cBehaviors.activeBehavior.behaviorName)
      {
        return true;
      } 
    }
    return false;
  }
  
  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static bool TryHardStopActiveBehavior(this ComponentBehaviors cBehaviors, MonoBehaviour coroutineSource)
  {
    var activeBehavior = cBehaviors.activeBehavior;
    if (activeBehavior == null) return true; // можно запускать другое поведение
    return activeBehavior.SkipRuleBehaviour(activeBehavior.e) && StopBehavior(cBehaviors, coroutineSource);
  }
  
  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static bool StopBehavior(this ComponentBehaviors cBehaviors, MonoBehaviour coroutineSource)
  {
    var activeBehavior = cBehaviors.activeBehavior;
    if (activeBehavior.stateBehavior != BehaviorState.ScheduleBehaviour)
      return true;
    
    activeBehavior.DisableBeh();
    activeBehavior.stateBehavior = activeBehavior.onceWork 
      ? BehaviorState.Off 
      : BehaviorState.ActiveTrigger;
    cBehaviors.activeBehavior = null;
    return true;
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static bool TryRunBehavior(this Ent entity, string behaviorName, AbstractBehavior inBehavior = null)
  {
    switch (inBehavior != null)
    {
      case true:
        inBehavior.stateBehavior = BehaviorState.TryScheduleBehaviour;
        return true;
      
      case false:
        var cBehaviors = entity.ComponentBehaviors();
        foreach (var behavior in cBehaviors.behaviors)
        {
          if (behavior.behaviorName.Equals(behaviorName))
          {
            behavior.stateBehavior = BehaviorState.TryScheduleBehaviour;
            return true;
          }
        }
        return false;
    }
  }
}
