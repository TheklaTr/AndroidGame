using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public float maxHorizontalSpeed;
    public float vertSpeed;

    private Rigidbody2D rigid;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();

        rigid.velocity = new Vector2(vertSpeed, maxHorizontalSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
