using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadSceneAsync("Game");
    }
    public void QuitGame()
    {
        Application.Quit();
    }   

    public void Age_5_6()
    {
        string fileName = "general_knowledge_5_6";
        PlayerPrefs.SetString("selectedAgeGroup", fileName);
        SceneManager.LoadSceneAsync("Game");
    }

    public void Age_7_8()
    {
        string fileName = "general_knowledge_7_8";
        PlayerPrefs.SetString("selectedAgeGroup", fileName);
        SceneManager.LoadSceneAsync("Game");
    }

    public void Age_9_10()
    {
        string fileName = "general_knowledge_9_10";
        PlayerPrefs.SetString("selectedAgeGroup", fileName);
        SceneManager.LoadSceneAsync("Game");
    }   

    public void Age_11_12()
    {
        string fileName = "general_knowledge_11_12";
        PlayerPrefs.SetString("selectedAgeGroup", fileName);
        SceneManager.LoadSceneAsync("Game");
    }
}
