using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MainMenu : MonoBehaviour
{

    public GameObject nameChangePanel;

    public TMP_InputField player1Name;
    public TMP_InputField player2Name;

    GameMaster gm;

    void Start()
    {
        gm = GameMaster.GM;
        
    }

    public void OpenNameChanger()
    {
        nameChangePanel.SetActive(true);
    }


    public void ChangeName()
    {
        gm.player1Name = player1Name.text;
        gm.player2Name = player2Name.text;
               
    }
}
