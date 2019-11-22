using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneScripts : MonoBehaviour
{
    GameMaster gm;

    

    // Start is called before the first frame update
    void Start()
    {
        gm = GameMaster.GM;
    }


    public void StartGame(int id)
    {
        SceneManager.LoadScene(id);
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
