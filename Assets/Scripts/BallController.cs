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


    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();

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

    public void ActivateBall()
    {
        ballActive = true;
        rigid.velocity = new Vector2(vertSpeed, vertSpeed);
    }
}
