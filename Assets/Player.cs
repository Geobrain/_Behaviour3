using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Ent {
    public int qq;
    private ComponentBehaviors cBehaviors;

    /*protected override void Setup(Player player) {
        cBehaviors = Component.AddGetComponentBehaviors(this);
        cBehaviors.test = 4;
        cBehaviors.behaviors.Add(new Player_inputQ());
        cBehaviors.behaviors.Add(new Player_inputW());
        ProcessorBehaviors.Instance.AddEntity(this);

        Debug.LogError($"  1111  {cBehaviors.test}  {cBehaviors.behaviors.Count} ");

    }*/



    public override void Setup(Ent ent) {
        cBehaviors = Component.AddGetComponentBehaviors(ent);
        cBehaviors.test = 4;
        cBehaviors.behaviors.Add(new Player_inputQ());
        cBehaviors.behaviors.Add(new Player_inputW());
        ProcessorBehaviors.Instance.AddEntity(this);
    }
}
