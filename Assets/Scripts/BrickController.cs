using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickController : MonoBehaviour
{
    [SerializeField] int brickValue;

    private GameManager gameManager;

    public GameObject scoreEffect;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DestroyBrick()
    {
        gameManager.AddScore(brickValue);

        GameObject scoreObject = (GameObject)Instantiate(scoreEffect, transform.position, transform.rotation);
        scoreObject.GetComponent<ScoreEffect>().scoreText.text = "" + brickValue;

        Destroy(gameObject);
    }
}
