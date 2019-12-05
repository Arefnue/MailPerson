using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerups : MonoBehaviour
{
    //Generator
    public List<GameObject> powers;
    GameObject scripts;
    GetRandomPointOnNavMesh rp;
    private int randomPowerID;
    public int MaxnumberOfPower = 2;
    

    //Time Management
    public float minTime = 5f;
    public float maxTime = 10f;
    private float time;
    private float spawnTime;


    GameMaster gm;

    private void Start() 
    {
        gm = GameMaster.GM;
        scripts = GameObject.FindGameObjectWithTag("Scripts");
        rp = scripts.GetComponent<GetRandomPointOnNavMesh>();

        SetRandomTime();
        time = minTime;
    }

    private void Update() 
    {   
        if(gm.currentNumberOfPower <= MaxnumberOfPower)
        {
            RandomSpawner();
        }
        
    }

    void RandomSpawner()
    {
        time += Time.deltaTime;
        
        if(time >= spawnTime)
        {
            time = 0;

            Spawn();

            SetRandomTime();
        }
    }

    void Spawn()
    {
        GetRandomPower();

        rp.CreatePower(powers[randomPowerID]);
        gm.currentNumberOfPower +=1;
    }

    void SetRandomTime()
    {
        spawnTime = Random.Range(minTime,maxTime);       
    }

    void GetRandomPower()
    {
        randomPowerID = Random.Range(0,powers.Count);
    }


}
