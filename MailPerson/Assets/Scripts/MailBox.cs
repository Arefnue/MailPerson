using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MailBox : MonoBehaviour
{
    GameMaster gm;

    private void Start() 
    {
        gm = GameMaster.GM;
    }

    private void OnTriggerEnter(Collider other) 
    {
        //Decide collided object is player
        if(other.CompareTag("Player"))
        {
            
            //Decide color of mailbox
            if(gameObject.CompareTag("RedMailBox"))
            {
                //Check the right player
                if(other.name == gm.redMailPerson)
                {                       
                    gm.redMailPerson = ""; //Reset the string
                    gm.redPostOn = false; // Create new post
                    Destroy(gameObject); // Destroy this mailbox

                }
            }
            else if(gameObject.CompareTag("BlueMailBox"))
            {
                //Check the right player
                if(other.name == gm.blueMailPerson)
                {
                    gm.blueMailPerson = ""; //Reset the string
                    gm.bluePostOn = false; // Create new post
                    Destroy(gameObject); // Destroy this mailbox
                }
            }
        }
    }

    
}
