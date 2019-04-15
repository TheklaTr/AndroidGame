using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string firstLevel;

    public void NewGame()
    {
        SceneManager.LoadScene(firstLevel);

        PlayerPrefs.SetInt("currentScore", 0);
        PlayerPrefs.SetInt("currentLives", 3);
        if(!PlayerPrefs.HasKey("HiScore"))
            PlayerPrefs.SetInt("HiScore", 0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
