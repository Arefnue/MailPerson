using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneScripts : MonoBehaviour
{
    GameMaster gm;

    public int startGameScene;

    // Start is called before the first frame update
    void Start()
    {
        gm = GameMaster.GM;
    }


    public void StartGame()
    {
        SceneManager.LoadScene(startGameScene);
        gm.ResetGameMaster();
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void ChangeScene(int id)
    {
        SceneManager.LoadScene(id);
    }   
}
