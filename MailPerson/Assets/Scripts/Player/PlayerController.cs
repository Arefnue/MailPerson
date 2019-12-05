using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Which player
    public int playerID;

    //Public variables
    public float movementSpeed;
    public int duration = 5;
    public float rotateSpeed = 180f;

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
        UsePower();
        if(!nameTaken)
        {
            TakePlayerNames();
        }
            
    }

    void Movement()
    {
        if(playerID == 1)
        {
            //Player1 axis 
            float horizontal_1 = Input.GetAxis("Horizontal1");
            float vertical_1 = Input.GetAxis("Vertical1");
            //Top-down vector config
            Vector3 movement_1 = new Vector3(horizontal_1,0,vertical_1);
            //Rotation
            transform.rotation = Quaternion.RotateTowards (transform.rotation, Quaternion.LookRotation (-movement_1), rotateSpeed * Time.deltaTime);
            //Move
            transform.Translate(movement_1 * movementSpeed * Time.deltaTime, Space.World);

            
        }
        else if(playerID == 2)
        {
            //Player2 axis
            float horizontal_2 = Input.GetAxis("Horizontal2");
            float vertical_2 = Input.GetAxis("Vertical2");
            //Top-down vector config
            Vector3 movement_2 = new Vector3(horizontal_2,0,vertical_2);
            //Rotation
            transform.rotation = Quaternion.RotateTowards (transform.rotation, Quaternion.LookRotation (-movement_2), rotateSpeed * Time.deltaTime);
            //Move
            transform.Translate(movement_2 * movementSpeed * Time.deltaTime, Space.World);
        }
        
    }

    void UsePower()
    {
        if(playerID == 1)
        {
            if(Input.GetButtonDown("UsePower1"))
            {
                
                StartCoroutine(Powers(gm.player1HasPowerID));
                gm.player1HasPowerID = -1;
            }
        }    
        else if(playerID == 2)
        {
            if(Input.GetButtonDown("UsePower2"))
            {
                
                StartCoroutine(Powers(gm.player2HasPowerID));
                gm.player2HasPowerID = -1;
            }
        }
    }

    void TakePlayerNames()
    {
        if(playerID == 1)
        {
            name = gm.player1Name;
            nameTaken = true;
        }
        else if(playerID == 2)
        {
            name = gm.player2Name;
            nameTaken = true;
        }      
    }
         

    IEnumerator Powers(int PowerID)
    {
        if(PowerID == -1)
        {
            yield return null;
        }
        else if(PowerID == 0)
        {
            //Move 2x
            movementSpeed = movementSpeed*2;
            yield return new WaitForSeconds(duration);
            movementSpeed = movementSpeed/2;
        }
        else if(PowerID == 1)
        {
            //Move 3x
            movementSpeed = movementSpeed*3;
            yield return new WaitForSeconds(duration);
            movementSpeed = movementSpeed/3;
        }
    }

}