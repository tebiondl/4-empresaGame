using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float speed = 6f;
    public float jumpPower = 6f;
    public bool grounded;
    public static int points;


    private bool jumping = false;
    private Rigidbody2D rb2d;
    private Animator anim;

    private Text Points;

    // Use this for initialization
    void Start()
    {
        points = 0;
        Points = GameObject.Find("Points").GetComponent<Text>();
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Points.text = points.ToString();

        anim.SetFloat("SpeedX", Mathf.Abs(rb2d.velocity.x));
        anim.SetBool("Grounded", grounded);
        anim.SetFloat("SpeedY", rb2d.velocity.y);

        float horizontal = Input.GetAxis("Horizontal");
        rb2d.velocity = new Vector2(horizontal * speed, rb2d.velocity.y);

        if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            if (grounded == true)
                rb2d.velocity = new Vector2(rb2d.velocity.x, jumpPower);

        }

        if (horizontal > 0.1f)
        {
            transform.localScale = new Vector3(3f, 3f, 1f);
        }

        if (horizontal < -0.1f)
        {
            transform.localScale = new Vector3(-3f, 3f, 1f);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Enemy")
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpPower/2);
        }
    }

    
}
