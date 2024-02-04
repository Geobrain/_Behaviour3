using System;
using System.Collections.Generic;
using UnityEngine;


public class ProcessorBehaviors : MonoBehaviour
{
  [HideInInspector] public static ProcessorBehaviors Inst;
  private List<Ent> source = new ();

  private void Awake()
  {
    Inst = this;
  }

  public void AddEntity(Ent entity)
  {
    var cBehaviors = entity.ComponentBehaviors();
    cBehaviors.activeBehavior = null;

    for (var i = 0; i < cBehaviors.behaviors.Count; i++)
    {
      var behavior = cBehaviors.behaviors[i];
#if UNITY_EDITOR
      if (behavior.behaviorName.Equals(BehaviorName._None))
      {
        Debug.LogError("Поведению не задано имя");
      }
#endif
      behavior.e = entity;
      behavior.OnEnable();
      behavior.SetBeh();
      behavior.stateBehavior = BehaviorState.ActiveTrigger;
      behavior.indexBehavior = i;
      cBehaviors.behaviors[i] = behavior;
    }
    source.Add(entity);
  }

  public void RemoveEntity(Ent entity)
  {
    var cBehaviors = entity.ComponentBehaviors();

    if (cBehaviors.activeBehavior != null)
    {
      var isSkipBehaviour = cBehaviors.activeBehavior.SkipRuleBehaviour(entity);
#if UNITY_EDITOR
      if (!isSkipBehaviour)
      {
        Debug.LogError($"ПРИНУДИТЕЛЬНОЕ ВЫКЛЮЧЕНИЕ ВСЕХ ПОВЕДЕНИЙ. Поведение не может завершить работу - {cBehaviors.activeBehavior.behaviorName} ");
      }
#endif
      //cBehaviors.activeBehavior.stateBehavior = BehaviorState.Off;
      cBehaviors.StopBehavior(this);
    }
    source.Remove(entity);
  }
  
  private int GetIndexActiveBehavior(ComponentBehaviors cBehaviors)
  {
    var index = 0;
    if (cBehaviors.activeBehavior != null)
    {
      index = cBehaviors.activeBehavior.indexBehavior;
    }
    return index;
  }

  public void Update()
  {
    foreach (var entity in source)
    {
      var cBehaviors = entity.ComponentBehaviors();

      for (var i = cBehaviors.behaviors.Count - 1; i >= 0 && i >= GetIndexActiveBehavior(cBehaviors); i--) // обрабатывает все поведения выше activeBehavior
      {
        var behavior = cBehaviors.behaviors[i];
        
        /*if (behavior.behaviorName == BehaviorName.ActorTest_inputE)
        {
          Debug.Log($" beh i = {i} {behavior.stateBehavior.ToString()}  ");
        } 
        */         

        switch (behavior.stateBehavior)
        {
          case BehaviorState.ActiveTrigger:
            if (behavior.IsTrigger())
            {
              entity.TryRunBehavior(behavior.behaviorName, behavior);
              goto case BehaviorState.TryScheduleBehaviour;
            }
            break;
          
          case BehaviorState.TryScheduleBehaviour:
            if (!cBehaviors.TryHardStopActiveBehavior(this))
            {
              behavior.stateBehavior = BehaviorState.ActiveTrigger;
              break; 
            }
            
            cBehaviors.activeBehavior = behavior;
            behavior.stateBehavior = BehaviorState.ScheduleBehaviour;
            behavior.PrepareWorkBehaviour();
            goto case BehaviorState.ScheduleBehaviour;

          case BehaviorState.ScheduleBehaviour:
            if (behavior.IsRunBehaviour()) // проход по шагам работающего поведения
            {
              if (behavior.canTransitionToSelf && behavior.IsTrigger())
              {
                Debug.Log($" перезапуск поведения ");
                behavior.SkipRuleBehaviour(entity);
                cBehaviors.StopBehavior(this);
                goto case BehaviorState.TryScheduleBehaviour;
              }
              
              break;
            }

            cBehaviors.StopBehavior(this);
            break;
        }
      }
    }
  }
}

