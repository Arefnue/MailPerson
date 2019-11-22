using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    //Player Names
    public TextMeshProUGUI player1Name;
    public TextMeshProUGUI player2Name;
    private bool playerNamesAdded = false;
    //Player scores
    public TextMeshProUGUI player1Score;
    public TextMeshProUGUI player2Score;
    //Timer
    public TextMeshProUGUI timeCounter;
    public float startTime = 60.0f;
    //Change scene
    public int nextScene;

    GameMaster gm;
    
    
    private void Start() 
    {
        gm = GameMaster.GM;

    }
    // Update is called once per frame
    void Update()
    {
        if(!playerNamesAdded)
        {
            player1Name.text = gm.player1Name;
            player2Name.text = gm.player2Name;
            playerNamesAdded = true;
        }

        player1Score.text = "x"+gm.score1.ToString();
        player2Score.text = gm.score2.ToString() + "x";
        
        TimeCount();
    }

    private void TimeCount()
    {
        startTime -= Time.deltaTime;
        
        timeCounter.text = Mathf.Round(startTime).ToString();

        if(startTime <= 0)
        {
            SceneScripts _scene = GameObject.FindGameObjectWithTag("Scripts").GetComponent<SceneScripts>();
            _scene.ChangeScene(nextScene);
        }
    }
}
