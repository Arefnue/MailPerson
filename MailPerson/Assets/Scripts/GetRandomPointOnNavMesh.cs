using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GetRandomPointOnNavMesh : MonoBehaviour
{
    //Random Point Config
    public float range = 10.0f;
    public int randomRange = 3;
    public float maxDistance = 1.0f;

    //Objects' Config
    public float postHeight = 0.25f;
    public float mailBoxHeight = 0.5f;

    //Prefabs
    public GameObject[] postPrefabs;
    public GameObject[] mailBoxPrefabs;


    GameMaster gm;

    private void Start() 
    {
        gm = GameMaster.GM;
    }
	

   
	void Update() 
    {  

		CreateObject();
        

	}

    void CreateObject()
    {
        Vector3 point; //Location of object created

		if (RandomPoint(transform.position, range, out point)) {
			    
            point.y = postHeight; //Fix object's y position

            //Check which post must be created
            if(!gm.redPostOn)
            {
                Instantiate(postPrefabs[0],point,Quaternion.identity); //Create red post
                gm.redPostOn = true; //Prevent creating new red post
                
                
            }
            else if(!gm.bluePostOn)
            {
                Instantiate(postPrefabs[1],point,Quaternion.identity); //Create blue post
                gm.bluePostOn = true; // Prevent creating new blue post
            }
            
		}
        
    }

    public void CreateMailBox(string whichColor)
    {   
        
        Vector3 point;
		if (RandomPoint(transform.position, range, out point)) 
        {   
            point.y = mailBoxHeight;
            
            if(whichColor == "Red")
            {
                
               Instantiate(mailBoxPrefabs[0],point,Quaternion.identity); 
            }
            else if(whichColor == "Blue")
            {
                
                Instantiate(mailBoxPrefabs[1],point,Quaternion.identity);
            }
        }

    }
    

    // Get random point on navmesh
    public bool RandomPoint(Vector3 center, float range, out Vector3 result) 
    {
        //Find appropriate location
		for (int i = 0; i < randomRange; i++) 
        {
			Vector3 randomPoint = center + Random.insideUnitSphere * range;

			NavMeshHit hit;

			if (NavMesh.SamplePosition(randomPoint, out hit, maxDistance, NavMesh.AllAreas)) {
				result = hit.position;
				return true;
			}
		}
		result = Vector3.zero;
		return false;
	}

}
