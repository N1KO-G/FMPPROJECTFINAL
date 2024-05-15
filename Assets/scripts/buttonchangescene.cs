using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class buttonchangescene : MonoBehaviour
{
    public string scene;

    public void sceneloader()
    {
        SceneManager.LoadScene(scene);
    }
}
