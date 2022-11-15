using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    private Vector3 localScale;
    private float dirX;
    public float speed;
    private Rigidbody2D rb2d;
    private bool facingRight = false;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        localScale = transform.localScale;
        dirX = -1f;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Obstacle")
        {
            dirX *= -1f;
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        rb2d.velocity = new Vector2(dirX * speed, rb2d.velocity.y);
    }

    private void LateUpdate()
    {
        CheckDirection();
    }

    void CheckDirection()
    {
        if(dirX > 0)
        {
            facingRight = false;
        }
        else if(dirX < 0)
        {
            facingRight = true;
        }

        if(((facingRight) && (localScale.x < 0)) || ((!facingRight) && (localScale.x > 0)))
        {
            localScale.x *= -1;
        }

        transform.localScale = localScale;
    }
}
