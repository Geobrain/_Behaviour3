using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;


public abstract class AbstractBehavior
{
  public bool isDebug;

  public bool IsDebug
  {
    get => isDebug;
    set => isDebug = value;
  }

  [KeyFilter(typeof(BehaviorName))] public string behaviorName;
  public bool onceWork; // поведение может сработать только один раз

  public bool canTransitionToSelf; // поведение может перезапустить само себя в процессе работы, если у него снова сработеат триггер

  public Ent e; // носитель поведения
  public BehaviorState stateBehavior = BehaviorState.Off;
  public int indexBehavior; //индекс поведения в массиве всех поведений обьекта
  
  public abstract void OnEnable();
  public abstract void SetBeh();
  public abstract void DisableBeh();

  public abstract bool SkipRuleBehaviour(Ent e); // способ уничтожения текущего поведения другим поведением с более высоким приоритетом

  public abstract bool IsTrigger();
  public abstract void PrepareWorkBehaviour();
  public abstract bool IsRunBehaviour();
}
