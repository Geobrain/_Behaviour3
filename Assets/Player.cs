using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Ent
{
    private ComponentBehaviors cBehaviors = new ComponentBehaviors();
    
    protected override void Setup()
    {

        cBehaviors.test = 4;
        cBehaviors.behaviors.Add(new Player_inputQ());
        cBehaviors.behaviors.Add(new Player_inputW());
        this.AddComponentBehaviors(cBehaviors);
        ProcessorBehaviors.Inst.AddEntity(this);
        
        
    }

}
