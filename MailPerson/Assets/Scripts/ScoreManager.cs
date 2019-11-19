using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI player1Score;
    public TextMeshProUGUI player2Score;
    public TextMeshProUGUI timeCounter;
    public float startTime = 60.0f;
    private int seconds;
    public int nextScene;
    GameMaster gm;
    
    
    private void Start() 
    {
        gm = GameMaster.GM;
               
    }
    // Update is called once per frame
    void Update()
    {
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
