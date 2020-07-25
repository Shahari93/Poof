using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneManagment : MonoBehaviour
{
    public void GotoSecondLevel()
    {
        SceneManager.LoadScene("FinalBetaScene2");
    }

    /*public void GotoThirdLevel()
    {
        SceneManager.LoadScene("menu");
    }

    public void GotoFourthLevel()
    {
        SceneManager.LoadScene("menu");
    }

    public void GotoFifthLevel()
    {
        SceneManager.LoadScene("menu");
    }*/
}
