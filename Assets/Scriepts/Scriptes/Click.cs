﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Click : MonoBehaviour
{

    // Use this for initialization
    public void LoadByIndex(int sceneIndex)
    {
        SceneManager.LoadScene(1);
    }
}