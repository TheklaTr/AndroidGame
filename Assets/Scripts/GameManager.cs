using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] bool gameActive;
    [SerializeField] Text livesText;
    [SerializeField] int lives;
    [SerializeField] GameObject gameOverScreen;
    [SerializeField] int currentScore;
    [SerializeField] Text scoreText;
    [SerializeField] GameObject pauseScreen;
    [SerializeField] GameObject levelWin;
    [SerializeField] Text hiScoreText;

    [SerializeField] Text multiplierText;
    [SerializeField] int currentMultiplier = 1;
    [SerializeField] int maxMultiplier = 8;

    private int currentHiScore;
    private BallController theBall;

    // Start is called before the first frame update
    void Start()
    {
        theBall = FindObjectOfType<BallController>();

        currentScore = PlayerPrefs.GetInt("currentScore");

        lives = PlayerPrefs.GetInt("currentLives");

        livesText.text = "LIVES REMAINING: " + lives;

        scoreText.text = "SCORE: " + currentScore;

        currentHiScore = PlayerPrefs.GetInt("HiScore");
        hiScoreText.text = "HI-SCORE: " + currentHiScore;

        Time.timeScale = 1f;

    }

    // Update is called once per frame
    void Update()
    {
        // Press the space only one time while running the game
        if (Input.GetKeyDown(KeyCode.Space) && !gameActive)
        {
            theBall.ActivateBall();
            gameActive = true;
        }

        // Pause screen
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            if (pauseScreen.activeSelf)
            {
                pauseScreen.SetActive(false);
                Time.timeScale = 1f;
            }
            else
            {
                pauseScreen.SetActive(true);
                Time.timeScale = 0;
            }
        }

        var brickCheck = FindObjectOfType<BrickController>();
        if (brickCheck == null)
        {
            PlayerPrefs.SetInt("currentScore", currentScore);
            PlayerPrefs.SetInt("HiScore", currentHiScore);

            levelWin.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void RespawnBall()
    {
        gameActive = false;

        // tracking lives
        lives -= 1;
        if (lives < 0)
        {
            theBall.gameObject.SetActive(false);

            gameOverScreen.SetActive(true);

            livesText.text = "ALL LIVES LOST";

            PlayerPrefs.SetInt("HiScore", currentHiScore);
        }
        else 
            livesText.text = "LIVES REMAINING: " + lives;

        PlayerPrefs.SetInt("currentLives", lives);
    }

    public void AddScore(int ScoreToAdd)
    {
        currentScore += ScoreToAdd + currentMultiplier;

        scoreText.text = "SCORE: " + currentScore;

        if (currentScore > currentHiScore)
        {
            currentHiScore = currentScore;
            hiScoreText.text = "HI-SCORE: " + currentHiScore;
        }
    }

    public void AddMultiplier()
    {
        currentMultiplier += 1;

        if (currentMultiplier > maxMultiplier)
        {
            currentMultiplier = maxMultiplier;
        }

        multiplierText.text = "CURRENT MULTIPLIER: " + currentMultiplier;
    }

    public void ResetMultiplier()
    {
        currentMultiplier = 1;
        multiplierText.text = "CURRENT MULTIPLIER: " + currentMultiplier;
    }
}
