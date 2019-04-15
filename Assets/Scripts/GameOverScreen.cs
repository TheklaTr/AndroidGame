using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    public void RestartLevel()
    {
        PlayerPrefs.SetInt("currentScore", 0);
        PlayerPrefs.SetInt("currentLives", 3);

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitToMain()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
