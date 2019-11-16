using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Taking player gameobjects
    public GameObject playerPrefab;
    List<GameObject> players = new List<GameObject>();

    //Public variables
    public float movementSpeed;

    GameMaster gm;

    private void Start() 
    {
        gm = GameMaster.GM; 
    }
     
    void Update()
    {
         FindPlayers();
         Movement();
         TakePlayerNames();
    }

    void Movement()
     {
        //Player1 axis 
        float horizontal_1 = Input.GetAxis("Horizontal1");
        float vertical_1 = Input.GetAxis("Vertical1");

        //Player2 axis
        float horizontal_2 = Input.GetAxis("Horizontal2");
        float vertical_2 = Input.GetAxis("Vertical2");

        //Top-down vector config
        Vector3 movement_1 = new Vector3(horizontal_1,0,vertical_1);
        Vector3 movement_2 = new Vector3(horizontal_2,0,vertical_2);

        //Move
        players[0].transform.Translate(movement_1 * movementSpeed * Time.deltaTime, Space.World);
        players[1].transform.Translate(movement_2 * movementSpeed * Time.deltaTime, Space.World);

     }

    void FindPlayers()
     {
         // Find player prefabs and list them
         foreach(GameObject player in GameObject.FindObjectsOfType (typeof(GameObject)))
         {
             if(player.tag == "Player" && !players.Contains(player))
                 players.Add (player);
         }
     }

    void TakePlayerNames()
    {
        if(gm.player1Name == "")
        {
            gm.player1Name = players[0].name;
        }
        if(gm.player2Name == "")
        {
            gm.player2Name = players[1].name;
        }
    }
         
}