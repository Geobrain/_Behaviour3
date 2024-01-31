using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private Player player;
    
    
    void Start()
    {
        player = new Player();
        

        Debug.LogError($"   ура  {player.ComponentBehaviors().www} ");
        
        Debug.LogError($"    {StorageComponentBehaviors.Instance.Components}  ");
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            player.Destroy();

            Debug.LogError($"    {StorageComponentBehaviors.Instance.Components}  ");
            

        }
    }
}
