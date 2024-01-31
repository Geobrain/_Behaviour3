using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;
using Time = UnityEngine.Time;


public partial class BehaviorName
{
  [FieldKey(categoryName = "Behaviors")] public const string Player_inputW = "Player_inputW";
}

[CreateAssetMenu(fileName = "Player_inputW", menuName = "Game/Behaviors/Player_inputW")]
public class Player_inputW : Behavior<Player_inputW>, IOneStepBehavior
{
  
  public Player_inputW()
  {
    behaviorName = BehaviorName.Player_inputW;
  }
  
  public override void SetBeh()
  {
  }
  
  public override void DisableBeh()
  {
  }

  public override bool SkipRuleBehaviour(Ent e)
  {
    return true;
  }

  public override bool IsTrigger()
  {
    if (Input.GetKeyDown(KeyCode.W))
    {
      return true;
    }
    return false;
  }

  #region Behaviour
  
  public bool stepBeh_0()
  {
    Debug.Log($" работает поведение Player_inputW ");
    
    return false;
  }

  #endregion
}

