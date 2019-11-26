using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerups : MonoBehaviour
{
    public List<GameObject> powers;

    GameMaster gm;

    private void Start() 
    {
        gm = GameMaster.GM;
    }



}
