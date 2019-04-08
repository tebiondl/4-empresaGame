using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollider : MonoBehaviour
{
    private Player player;



    // Use this for initialization
    void Start()
    {
        player = GetComponentInParent<Player>();
    }

    void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.tag == "Floor" || col.gameObject.tag == "MovingPlatform")
        {
            player.grounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag == "Floor" || col.gameObject.tag == "MovingPlatform")
        {
            player.grounded = false;
        }
    }
}
