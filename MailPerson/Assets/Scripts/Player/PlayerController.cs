using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Taking player gameobjects
    public GameObject player1;
    public GameObject player2;

    //Public variables
    public float movementSpeed;

    //Bool
    private bool nameTaken = false;

    GameMaster gm;

    private void Start() 
    {
        gm = GameMaster.GM; 
    }
     
    void Update()
    {
        
        Movement();
        if(!nameTaken)
        {
            TakePlayerNames();
        }
            
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
        player1.transform.Translate(movement_1 * movementSpeed * Time.deltaTime, Space.World);
        player2.transform.Translate(movement_2 * movementSpeed * Time.deltaTime, Space.World);

    }

    void TakePlayerNames()
    {
        player1.name = gm.player1Name;
        player2.name = gm.player2Name;
        nameTaken = true;
    }
         
}