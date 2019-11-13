using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Post : MonoBehaviour
{
    GameObject scripts;
    GetRandomPointOnNavMesh randomComponent;
    GameMaster gm;

    public string playerName;

    
    void Start()
    {
        scripts = GameObject.FindGameObjectWithTag("Scripts");
        randomComponent = scripts.GetComponent<GetRandomPointOnNavMesh>();
        gm = GameMaster.GM;
        

    }

    private void OnTriggerEnter(Collider other) 
    {
        //Check other is player
        if(other.CompareTag("Player"))
        {
            
            playerName = other.name; //Name of collided player

            //Determine which color of post
            if(gameObject.CompareTag("RedPost"))
            {   
                
                gm.redMailPerson = playerName; //Determine which player can access redmailbox
                randomComponent.CreateMailBox("Red");  //Create redmailbox
                                         
            }
            else if(gameObject.CompareTag("BluePost"))
            {
                
                gm.blueMailPerson = playerName; //Determine which player can access bluemailbox
                randomComponent.CreateMailBox("Blue"); //Create bluemailbox
                
                
            }

            Destroy(gameObject); // Destroy this post
            
        }    
    }
}
