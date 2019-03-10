using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private BallController theBall;

    [SerializeField] bool gameActive;

    // Start is called before the first frame update
    void Start()
    {
        theBall = FindObjectOfType<BallController>();
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
}
