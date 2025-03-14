using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBehavior : MonoBehaviour
{
    public Vector2 jumpForce = new Vector2(0, 1250);

    private Rigidbody2D rb2D;
    private Animator anim;
    private bool isWalking;
    public AudioClip hitSound;
    public AudioClip barkSound;
    public AudioClip bellSound;
    public AudioClip powerSound;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    public float speed;
    public float Timer;
    bool JumpCooldown = false;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && !JumpCooldown)
        {
            rb2D.velocity = Vector2.zero;

            rb2D.AddForce(jumpForce);
            JumpCooldown = true;
        }

        float xMove = Input.GetAxis("Horizontal");
        Vector3 playerPos = transform.position;
        playerPos.x += xMove * Time.deltaTime * speed;
        transform.position = playerPos;
        
        if(xMove == 0)
        {
            isWalking = false;
            anim.SetTrigger("goToIdle");
        }
        else if(isWalking != true)
        {
            isWalking = true;
            anim.SetTrigger("goToWalkCycle");
        }
        
        if(Timer > 0)
        {
            speed = 10;
            Timer = Timer - Time.deltaTime;
        }
        if(Timer <= 0)
        {
            speed = 5;
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        GameController gc = FindObjectOfType<GameController>();

        if (collision.gameObject.tag == "Obstacle")
        {
            print("Oops");

            Vector3 camPos = Camera.main.transform.position;
            AudioSource.PlayClipAtPoint(hitSound, camPos);

            gc.UpdateLives();
        }

        if(collision.gameObject.tag == "Enemy")
        {
            Vector3 camPos = Camera.main.transform.position;
            AudioSource.PlayClipAtPoint(barkSound, camPos);

            gc.UpdateLives();
        }

        if (collision.gameObject.tag == "PowerUp1")
        {
            Timer = 3;
            Destroy(collision.gameObject);

            Vector3 camPos = Camera.main.transform.position;
            AudioSource.PlayClipAtPoint(powerSound, camPos);
        }


        if(collision.gameObject.tag == "Obstacle2")
        {
            JumpCooldown = false;
        }

        if(collision.gameObject.tag == "Goal")
        {
            gc.WinLevel();
        }

        if(collision.gameObject.name == "doorframe")
        {
            SceneManager.LoadScene(2);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        GameController gc = FindObjectOfType<GameController>();

        if (collision.gameObject.name == "Goal")
        {
            Vector3 camPos = Camera.main.transform.position;
            AudioSource.PlayClipAtPoint(bellSound, camPos);

            gc.WinLevel();
        }

        if (collision.gameObject.name == "Work")
        {
            gc.WinGame();
        }
    }
}
