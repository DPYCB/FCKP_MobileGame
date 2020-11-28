using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Player : MonoBehaviour
{

    private Rigidbody2D playerBody;

    private float speed = 12f;
    public Text scoreText;
    public Text highScoreText;
    public Camera cam;

    private Vector2 levelBounds;
    private string levelName;

    private Boolean facingRight = false;

    void Start()
    {
        playerBody = GetComponent<Rigidbody2D>();
        levelName = PlayerPrefs.GetString("currentLevel");
        string levelScore = levelName + "Score";
        PlayerPrefs.SetString(levelScore, "0");
        try
        {
            highScoreText.text = PlayerPrefs.GetString(levelName + "HighScore");
        }

        catch(Exception e)
        {
            highScoreText.text = "0";
        }

        levelBounds = cam.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
    }

    void Update()
    {
        transform.position = new Vector2(Mathf.Clamp(transform.position.x,
            (-levelBounds.x + transform.GetComponent<SpriteRenderer>().bounds.size.x / 2),
            levelBounds.x - transform.GetComponent<SpriteRenderer>().bounds.size.x / 2),
            transform.position.y);
    }

    void FixedUpdate()
    {
        touchMove();

        if (playerBody.velocity.x != 0)
        {
            //Anim for side Jump
            playerBody.GetComponent<Animator>().SetTrigger("isMoving");
        }       

        checkFlip(playerBody.velocity);
    }

    private void touchMove()
    {
        // velocity movement
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            Vector2 touchPos = Input.GetTouch(0).deltaPosition;
            Vector2 vel = playerBody.velocity;
            vel.x = touchPos.x * Time.fixedDeltaTime * speed;
            playerBody.velocity = vel;
        }
        /*
        else if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            playerBody.velocity = new Vector2(0f, playerBody.velocity.y);
        }
        */
        else
        {
            playerBody.velocity = new Vector2(0f, playerBody.velocity.y);
        }
    }

    private void checkFlip(Vector2 speed)
    {
        if (speed.x > 0 && !facingRight)
        {
            Flip();
        }
        else if (speed.x < 0 && facingRight)
        {
            Flip();
        }
    }

    private void Flip()
    {
        facingRight = !facingRight;

        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bonus")
        {
            AddScore();
            FindObjectOfType<AudioManager>().Play("Bonus");
            Destroy(collision.gameObject);
        }
    }

    private void AddScore()
    {
        int res = 0;
        Int32.TryParse(scoreText.text, out res);
        res += 500;
        scoreText.text = "" + res;
        string levelScore = PlayerPrefs.GetString("currentLevel") + "Score";
        PlayerPrefs.SetString(levelScore, scoreText.text);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform" || collision.gameObject.tag == "Platform_Ghost")
        {
            //Anim for jump            
            playerBody.GetComponent<Animator>().SetTrigger("isJumping");           
        }
    }
}
