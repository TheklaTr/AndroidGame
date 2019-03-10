using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float direction;
    [SerializeField] float adjustSpeed;

    [SerializeField] Transform rightLimit;
    [SerializeField] Transform leftLimit;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position = new Vector3(transform.position.x + speed * Time.deltaTime,
                transform.position.y, transform.position.z);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position = new Vector3(transform.position.x - speed * Time.deltaTime,
                transform.position.y, transform.position.z);
        }
        else
            direction = 0;

        if (transform.position.x > rightLimit.position.x)
        {
            transform.position = new Vector3(rightLimit.position.x, 
                transform.position.y, transform.position.z);
        }
        else if (transform.position.x < leftLimit.position.x)
        {
            transform.position = new Vector3(leftLimit.position.x,
                transform.position.y, transform.position.z);
        }
    }

    // stop moving when touch the walls 
    private void OnCollisionEnxit2D(Collision2D other)
    {
        other.rigidbody.velocity = new Vector2(other.rigidbody.velocity.x + direction * adjustSpeed,
                            other.rigidbody.velocity.y);
        Debug.Log(other.rigidbody.velocity);
    }
}
