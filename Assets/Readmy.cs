using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Readmy : MonoBehaviour
{
    private Player player;
    
    /*todo

дестроить дату в момент удаления сущности
		
дату сделать для обьектов - классов. 
		
Добавить фильтры сущностей

парсинг джейсона в дату - нужна общая система заполнения даты из джейсона
     
     */
    
    
    void Start()
    {
        player = new Player();
        player.Set(DataBase.Pawns.Gunner);
        
        var speedWalk = player.DataMotion().speedWalk;

        Debug.Log($" 222  {player.ComponentBehaviors().test} ||  {player.ComponentBehaviors().behaviors.Count} || speedWalk {speedWalk} ");
        
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
