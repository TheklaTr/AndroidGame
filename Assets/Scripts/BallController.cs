using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] float maxHorizontalSpeed;
    [SerializeField] float vertSpeed;
    [SerializeField] bool ballActive;

    [SerializeField] Transform startPoint;

    private Rigidbody2D rigid;
    private GameManager gameManager;

    [SerializeField] AudioSource ballBounce;
    [SerializeField] AudioSource ballDead;
    [SerializeField] AudioSource brickHit;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        gameManager = FindObjectOfType<GameManager>();

        //rigid.velocity = new Vector2(vertSpeed, maxHorizontalSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        if (!ballActive)
        {
            rigid.velocity = Vector2.zero;
            transform.position = startPoint.position;
        }

        if (rigid.velocity.x > maxHorizontalSpeed)
        {
            rigid.velocity = new Vector2(maxHorizontalSpeed, rigid.velocity.x);
        }
        else if (rigid.velocity.x < -maxHorizontalSpeed)
        {
            rigid.velocity = new Vector2(-maxHorizontalSpeed, rigid.velocity.y);
        }

        Debug.Log(rigid.velocity);
    }

    // Destroy the bricks
    private void OnCollisionExit2D(Collision2D collision)
    {

        if (ballBounce.isPlaying)
        {
            ballBounce.Stop();
            ballBounce.Play();
        }
        else
        {
            ballBounce.Play();
        }

        if (collision.gameObject.tag == "Brick")
        {
            collision.gameObject.GetComponent<BrickController>().DestroyBrick();

            if (brickHit.isPlaying)
            {
                brickHit.Stop();
                brickHit.Play();
            }
            else
            {
                brickHit.Play();
            }

            gameManager.AddMultiplier();
        }
        else if (collision.gameObject.tag != "Player")
        {
            gameManager.ResetMultiplier();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Respawn")
        {
            ballActive = false;
            gameManager.RespawnBall();

            gameManager.ResetMultiplier();

            ballDead.Play();
        }
    }

    public void ActivateBall()
    {
        ballActive = true;
        rigid.velocity = new Vector2(Random.Range(-vertSpeed, vertSpeed), vertSpeed);
    }
}
