using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{
    public float speed = 0;
    private float orientation;
    public Transform finish, bottomFinish;
    private Transform start;
    private bool detectPlatform = false;
    private bool grounded = false;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        orientation = 1;
    }

    // Update is called once per frame
    void Update()
    {
        start = transform;

        rb.velocity = new Vector2(-orientation * speed, rb.velocity.y);

        Vector2 direction = new Vector2(finish.position.x - start.position.x, transform.position.y);
        Vector2 hit2Start = new Vector2(bottomFinish.position.x, transform.position.y);
        Vector2 hit2Finish = new Vector2(bottomFinish.position.x, bottomFinish.position.y);
        Vector2 direction2 = hit2Finish - hit2Start;

        RaycastHit2D hit = Physics2D.Raycast(start.position, direction, 2);
        RaycastHit2D hit2 = Physics2D.Raycast(new Vector2(bottomFinish.position.x, transform.position.y), direction2, 2);

        if (hit.collider.gameObject.tag == "Floor")
        {
            detectPlatform = true;
        }
        else
        {
            detectPlatform = false;
        }

        if(!hit2.collider && grounded)
        {
            detectPlatform = true;
        }
        else
        {
            detectPlatform = false;
        }

        Debug.DrawLine(start.position, finish.position, Color.green);
        Debug.DrawLine(new Vector2(bottomFinish.position.x, transform.position.y), new Vector2(bottomFinish.position.x, bottomFinish.position.y), Color.red);
        Debug.Log(hit.collider.gameObject.tag);


        if (detectPlatform)
        {
            if (orientation > 0)
            {
                orientation = -1;
            }
            else if (orientation < 0)
            {
                orientation = 1;
            }
        }

        if (orientation > 0.1f)
        {
            transform.localScale = new Vector3(3f, 3f, 1f);
        }

        if (orientation < -0.1f)
        {
            transform.localScale = new Vector3(-3f, 3f, 1f);
        }
    }

    void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.tag == "Floor")
        {
            grounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag == "Floor")
        {
            grounded = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
