using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Ent
{
    private ComponentBehaviors cBehaviors = new ComponentBehaviors();
    
    protected override void Setup()
    {

        cBehaviors.www = 4;
        // тут дата настроек для компонента cBehaviors - добавляем в него классы-поведения
        this.AddComponentBehaviors(cBehaviors);
    }

}
