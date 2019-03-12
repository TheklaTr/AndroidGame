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

    private BallController theBall;

    // Start is called before the first frame update
    void Start()
    {
        theBall = FindObjectOfType<BallController>();

        livesText.text = "LIVES REMAINING: " + lives;

        scoreText.text = "SCORE: " + currentScore;

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
        }
        else 
            livesText.text = "LIVES REMAINING: " + lives;   
    }

    public void AddScore(int ScoreToAdd)
    {
        currentScore += ScoreToAdd;

        scoreText.text = "SCORE: " + currentScore;
    }
}
