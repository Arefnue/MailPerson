using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GameMaster : MonoBehaviour
{
    public static GameMaster GM;

    //Player Names
    public string player1Name = "Player 1";
    public string player2Name = "Player 2";
    
    //Hold which player takes which post
    public string redMailPerson = "";  
    public string blueMailPerson = "";

    //Create new post
    public bool redPostOn = false;
    public bool bluePostOn = false;

    //Score
    public int score1 = 0;
    public int score2 = 0;

    //Powerups
    //Speed
    public int player1Speed = 5;
    public int player2Speed = 5;
  
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

    public void ResetGameMaster()
    {
        //Player Names
        player1Name = "Player 1";
        player2Name = "Player 2";
        
        //Hold which player takes which post
        redMailPerson = "";  
        blueMailPerson = "";

        //Create new post
        redPostOn = false;
        bluePostOn = false;

        //Score
        score1 = 0;
        score2 = 0;
    }
}
