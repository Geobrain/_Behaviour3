using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private Player player;
    
    
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
