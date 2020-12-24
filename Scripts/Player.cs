using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] private int health;
    public int numOfHearts;
    
    [SerializeField]private float speed = 10;
    [SerializeField]private float jumpForce = 3;

    public Transform footPosition;

    public Rigidbody2D body;

    public Animator anim;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    private bool isFacingRight = true;
    public bool grounded = false;
    public bool attacking;
    private bool running;

    public EnemyAI enemyScript;

    public GameObject player;
    public GameObject restartButton;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        enemyScript = gameObject.GetComponent<EnemyAI>();
        restartButton.SetActive(false);

    }

    private void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal");
        Move(x);
        Attack();
        ShowPlayersHealth();

        if(SceneManager.GetActiveScene().name == "LevelOne" && transform.position.y < -9.8f)
        {
            GameOver();
        }

        else if (SceneManager.GetActiveScene().name == "LevelTwo" && transform.position.y < -9.8f)
        {
            GameOver();
        }

        else if (SceneManager.GetActiveScene().name == "LevelThree" && transform.position.y < -6.5f)
        {
            GameOver();
        }



        if (SceneManager.GetActiveScene().name == "BossOne")
            {
              jumpForce = 10;
            }

        if (SceneManager.GetActiveScene().name == "BossTwo")
        {
            jumpForce = 10;
        }

        if (SceneManager.GetActiveScene().name == "BossThree")
        {
            jumpForce = 10;
        }

        else if (SceneManager.GetActiveScene().name == "AllBosses")
        {
            jumpForce = 10;
        }

        if (health == 0)
        {
            GameOver();
        }

        if (Input.GetKey(KeyCode.UpArrow) && grounded == true)
        {
            grounded = false;
            Jump();
            anim.SetBool("isJumping", true);
        }


        //Flip the player according to velocity

        if (x < 0 && isFacingRight)//If the player is facing towards the right and left arrow is pressed
        {
            FlipPlayer();
        }
        else if (x > 0 && !isFacingRight)//If the player is facing towards the left and right arrow is pressed
        {
            FlipPlayer();
        }
    }

    private void Move(float x)
    {
        if(Input.GetKey(KeyCode.RightArrow))
        {
            anim.SetBool("isRunning", true);
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            running = true;
        }

        else if(Input.GetKeyUp(KeyCode.RightArrow))
        {
            anim.SetBool("isRunning", false);
            running = false;
        }

        if(Input.GetKey(KeyCode.LeftArrow))
        {
            anim.SetBool("isRunning", true);
            transform.Translate(Vector2.left * speed * Time.deltaTime);
            running = true;
        }

        else if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            anim.SetBool("isRunning", false);
            running = false;
        }
    }

    private void Attack()
    {
        if(Input.GetKey(KeyCode.Space) && running == false)
        {
            anim.SetBool("isAttacking", true);
            player.tag = "Attacking";
        }

        else 
        {
            anim.SetBool("isAttacking", false);
            player.tag = "Player";
        }
    }

    private void Jump()
    {
        Vector2 newVelocity = new Vector2(body.velocity.x, jumpForce); //Keep 'x' same and change 'y'
        body.velocity = newVelocity;
    }

    private void FlipPlayer()
    {   
        isFacingRight = !isFacingRight;
        Vector2 scale = transform.localScale;
        scale.x *= -1;//flip the x axis
        transform.localScale = scale;
    }

    private void ShowPlayersHealth()
    {
        if (health > numOfHearts)
        {
            health = numOfHearts;
        }

        for (int i = 0; i < hearts.Length; i++)
        {

            if (i < health)
            {
                hearts[i].sprite = fullHeart;
            }

            else
            {
                hearts[i].sprite = emptyHeart;
            }

            if (i < numOfHearts)
            {
                hearts[i].enabled = true;
            }

            else
            {
                hearts[i].enabled = false;
            }
        }
    }

    private void GameOver()
    {
        Time.timeScale = 0;
        restartButton.SetActive(true);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            grounded = true;
            anim.SetBool("isJumping", false);
        }

        if (collision.gameObject.tag == "Enemy" && player.tag == "Player")
        {
            health--;
            transform.position = new Vector3(transform.position.x - 1.5f, transform.position.y);
        }

        if(collision.gameObject.tag == "EnemyTwo" && player.tag == "Player")
        {
            health = health - 2;
        }

        if(collision.gameObject.tag == "MiniBosses")
        {
            health--;
        }

        else if (collision.gameObject.tag == "BigBosses")
        {
            health = 0;
        }

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.name == "PortalBlue" && Input.GetKey("x"))
        {
            Debug.Log("Seu Cu");
            SceneManager.LoadScene("TutorialOne");
        }

        else if (collision.gameObject.name == "PortalRed" && Input.GetKey("x"))
        {
            Debug.Log("Cu");
            SceneManager.LoadScene("TutorialTwo");
        }

        else if (collision.gameObject.name == "PortalPurple" && Input.GetKey("x"))
        {
            Debug.Log("Caralhitos");
            SceneManager.LoadScene("TutorialThree");
        }
    }
}
