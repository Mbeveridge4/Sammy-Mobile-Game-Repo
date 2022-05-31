using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelScripts : MonoBehaviour
{
    // Sets the commands that each button does
  public void StartGame ()
    {
        //sets the default PlayerPrefs values on first start
        PlayerPrefs.SetInt("level", 1);
        PlayerPrefs.SetFloat("happy", 50);
        //loads scene 1
        SceneManager.LoadScene("SammyLevel1");
    }

    public void QuitGame()
    {
        //exits the Application
        Application.Quit();
    }

    public void MainMenu()
    {
        //loads main menu
        SceneManager.LoadScene("MainMenu");
    }
    public void Level2()
    {
        //loads level2
        SceneManager.LoadScene("SammyLevel2");
    }
    public void Instructions()
    {
        //Loads Instructions/Tutorial
        SceneManager.LoadScene("Tutorial");
    }
}
