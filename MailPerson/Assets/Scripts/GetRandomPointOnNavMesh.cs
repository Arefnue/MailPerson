using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GetRandomPointOnNavMesh : MonoBehaviour
{
    public float range = 10.0f;
    public int numberOfPost = 3;
    public float maxDistance =1.0f;

    public GameObject[] prefabs;

    public bool redPostOn = false;
    public bool bluePostOn = false;
    /*public bool yellowPostOn = false;
    public bool greenPostOn = false;*/
	

   
	void Update() 
    {
        
		CreateObject();

	}

    void CreateObject()
    {
        Vector3 point;
		if (RandomPoint(transform.position, range, out point)) {
			Debug.DrawRay(point, Vector3.up, Color.blue, 1.0f);
            
            point.y = 0.25f;

            if(!redPostOn)
            {
                Instantiate(prefabs[0],point,Quaternion.identity);
                redPostOn = true;
                
            }
            else if(!bluePostOn)
            {
                Instantiate(prefabs[1],point,Quaternion.identity);
                bluePostOn = true;
            }
            /*else if(!yellowPostOn)
            {
                Instantiate(prefabs[2],point,Quaternion.identity);
                yellowPostOn = true;
            }
            else if(!greenPostOn)
            {
                Instantiate(prefabs[3],point,Quaternion.identity);
                greenPostOn = true;
            }*/
		}
        
    }

    // Get random point on navmesh
    bool RandomPoint(Vector3 center, float range, out Vector3 result) {
		for (int i = 0; i < numberOfPost; i++) {
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
