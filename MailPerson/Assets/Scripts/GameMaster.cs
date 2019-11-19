using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GameMaster : MonoBehaviour
{
    public static GameMaster GM;

    //Player Names
    public string player1Name = "";
    public string player2Name = "";
    
    //Hold which player takes which post
    public string redMailPerson = "";  
    public string blueMailPerson = "";

    //Create new post
    public bool redPostOn = false;
    public bool bluePostOn = false;
  
    private void Awake() 
    {
        //Singleton
        if(GM == null)
        {
            GM = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            //Prevent dublicates
            Destroy(gameObject);
        }  
    }


}
