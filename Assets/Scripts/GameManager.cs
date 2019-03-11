using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] bool gameActive;
    [SerializeField] Text livesText;
    [SerializeField] int lives;

    private BallController theBall;

    // Start is called before the first frame update
    void Start()
    {
        theBall = FindObjectOfType<BallController>();

        livesText.text = "LIVES REMAINING: " + lives;

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
        livesText.text = "LIVES REMAINING: " + lives;
    }
}
