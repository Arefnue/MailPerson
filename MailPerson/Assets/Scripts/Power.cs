using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Power : MonoBehaviour
{
    public int powerID;

    GameMaster gm;

    private void Start() 
    {
        gm = GameMaster.GM;
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.CompareTag("Player"))
        {
            //Which player trigger
            if(other.name == gm.player1Name)
            {
                gm.player1HasPowerID = powerID;
                
                gm.currentNumberOfPower -=1;
                Destroy(gameObject);
            }
            else if(other.name == gm.player2Name)
            {
                gm.player2HasPowerID = powerID;
                
                gm.currentNumberOfPower -=1;
                Destroy(gameObject);
            }

        }   

    }
    
}
