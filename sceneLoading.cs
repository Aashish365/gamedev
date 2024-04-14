using MalbersAnimations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneLoading : MonoBehaviour
{
    public void Exit()
    {
        Application.Quit();
    }
    public void StartGame()
    {
        SceneManager.LoadScene("mainGame");
    }
    public void Back()
    {
        SceneManager.LoadScene("mainMenu");
    }
    public void playerDead()
    {
        SceneManager.LoadScene("loseScene");
    }
    void Update()
    {
        if ((Input.GetKey(KeyCode.Tab)))
        {
            Back();
        }

    }

}