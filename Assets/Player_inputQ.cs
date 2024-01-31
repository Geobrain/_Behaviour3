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
  [FieldKey(categoryName = "Behaviors")] public const string Player_inputQ = "Player_inputQ";
}

[CreateAssetMenu(fileName = "Player_inputQ", menuName = "Game/Behaviors/Player_inputQ")]
public class Player_inputQ : Behavior<Player_inputQ>, IOneStepBehavior
{
  public Player_inputQ()
  {
    behaviorName = BehaviorName.Player_inputQ;
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
    if (Input.GetKeyDown(KeyCode.Q))
    {
      return true;
    }
    return false;
  }

  #region Behaviour
  
  public bool stepBeh_0()
  {
    Debug.Log($" работает поведение Player_inputQ ");
    
    return false;
  }

  #endregion
}

