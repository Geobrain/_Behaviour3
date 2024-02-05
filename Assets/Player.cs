using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Ent
{
    private ComponentBehaviors cBehaviors;
    
    protected override void Setup() {
        cBehaviors = this.AddGetComponentBehaviors();
        cBehaviors.test = 4;
        cBehaviors.behaviors.Add(new Player_inputQ());
        cBehaviors.behaviors.Add(new Player_inputW());
        ProcessorBehaviors.Instance.AddEntity(this); 

        
        
    }

}
