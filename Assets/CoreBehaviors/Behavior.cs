using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class BehaviorName
{
  [FieldKey(categoryName = "Behaviors")] public const string _None = "_None";
}


public enum BehaviorState
{
  Off,
  ActiveTrigger,
  TryScheduleBehaviour,
  ScheduleBehaviour,
}
  
public abstract class Behavior<T> : AbstractBehavior
{
  private List<Func<bool>> behaviours = new List<Func<bool>>();
  private Behavior<T> InstanceInternal;
  private int behaviorStep;
  
  public Behavior(string name)
  {
    behaviorName = name;
  }
  
  public override void OnEnable() 
  {
    if (!Application.isPlaying || InstanceInternal != null) return;
    Initialization();
  }    

  private void Initialization()
  {
    InstanceInternal = this;
    
    if (InstanceInternal is IOneStepBehavior oneStepBehavior)
    {
      behaviours.Add(oneStepBehavior.stepBeh_0);
    }
    else if (InstanceInternal is ITwoStepBehavior twoStepBehavior)
    {
      behaviours.Add(twoStepBehavior.stepBeh_0);
      behaviours.Add(twoStepBehavior.stepBeh_1);
    }
    else if (InstanceInternal is IThreeStepBehavior threeStepBehavior)
    {
      behaviours.Add(threeStepBehavior.stepBeh_0);
      behaviours.Add(threeStepBehavior.stepBeh_1);
      behaviours.Add(threeStepBehavior.stepBeh_2);
    }
    else if (InstanceInternal is IFourStepBehavior fourStepBehavior)
    {
      behaviours.Add(fourStepBehavior.stepBeh_0);
      behaviours.Add(fourStepBehavior.stepBeh_1);
      behaviours.Add(fourStepBehavior.stepBeh_2);
      behaviours.Add(fourStepBehavior.stepBeh_3);
    }
    else if (InstanceInternal is IFiveStepBehavior fiveStepBehavior)
    {
      behaviours.Add(fiveStepBehavior.stepBeh_0);
      behaviours.Add(fiveStepBehavior.stepBeh_1);
      behaviours.Add(fiveStepBehavior.stepBeh_2);
      behaviours.Add(fiveStepBehavior.stepBeh_3);
      behaviours.Add(fiveStepBehavior.stepBeh_4);
    }
  }

  public override void PrepareWorkBehaviour()
  {
    behaviorStep = 0;
  }

  public override bool IsRunBehaviour()
  {
    do
    {
      if (!behaviours[behaviorStep].Invoke())
      {
        return true;
      }
      behaviorStep++;
    } while (behaviorStep < behaviours.Count);
    return false;
  }

}
