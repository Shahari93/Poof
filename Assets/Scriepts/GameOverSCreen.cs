using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverSCreen : MonoBehaviour
{
    public static int lastScene;

    public void Restart()
    {
        Debug.Log("last scene loaded");
        SceneManager.LoadScene(lastScene);
    }

    public void Exit()
    {
        
        SceneManager.LoadScene("Menu");
    }
}
