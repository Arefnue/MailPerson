using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Post : MonoBehaviour
{
    GameObject scripts;
    
    // Start is called before the first frame update
    void Start()
    {
        scripts = GameObject.FindGameObjectWithTag("Scripts");

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.CompareTag("Player"))
        {
            if(gameObject.CompareTag("RedPost"))
            {
                scripts.GetComponent<GetRandomPointOnNavMesh>().redPostOn = false;
            }
            else if(gameObject.CompareTag("BluePost"))
            {
                scripts.GetComponent<GetRandomPointOnNavMesh>().bluePostOn = false;
            }
            Destroy(gameObject);
        }    
    }
}
