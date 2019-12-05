using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOver : MonoBehaviour
{
    //Player Names
    public TextMeshProUGUI player1Name;
    public TextMeshProUGUI player2Name;
    private bool playerNamesAdded = false;
    //Player scores
    public TextMeshProUGUI player1Score;
    public TextMeshProUGUI player2Score;

    GameMaster gm;
    
    void Start()
    {
        gm = GameMaster.GM;
    }

    
    void Update()
    {
        if(!playerNamesAdded)
        {
            player1Name.text = gm.player1Name;
            player2Name.text = gm.player2Name;
            playerNamesAdded = true;
        }

        player1Score.text = gm.score1.ToString();
        player2Score.text = gm.score2.ToString();
    }
}
