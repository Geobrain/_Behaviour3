using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Readmy : MonoBehaviour
{
    private Player player;
    
    /*todo

убрать под капот добавление компонентов сущности и попадание поведений в процессор. вида cBehaviors = addgetcomponent

        cBehaviors.test = 4;
        cBehaviors.behaviors.Add(new Player_inputQ());
        cBehaviors.behaviors.Add(new Player_inputW());
        this.AddComponentBehaviors(cBehaviors);
        ProcessorBehaviors.Inst.AddEntity(this); // todo в момент добавления к процессору первой сущности создается синглотон процессора
		
		
добавить базу данных - обжект - черзе нее настраивать систему поведений		
		
		
Добавить фильтры сущностей

     
     */
    
    
    void Start()
    {
        player = new Player();
        

        Debug.Log($" создан игрок. значение поля test  {player.ComponentBehaviors().test} ");

        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            player.Destroy();

        }
    }
}
