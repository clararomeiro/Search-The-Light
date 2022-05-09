using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Player")]
    [SerializeField]
    private Rigidbody2D rb;

    [Header("Movement Config")]
    [SerializeField]
    private float vel;
    private float xdir;
    [SerializeField]
    private float jumpforce;

    [Header("Animation Config")]
    [SerializeField]
    private Animator playeranim;


    private bool canJump;

    private Vector3 left;
    private Vector3 right;

    [Header("Bullet")]
    [SerializeField]
    private GameObject bullet;
    [SerializeField]
    private GameObject bulletPlace;

    private bool canAttack;

    private bool isLeft;


    private float immortalTime;

    [SerializeField]
    private GameObject capsule;

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("EnemyKilled", 0);
        right = transform.localScale;
        left = transform.localScale;
        left.x *= -1;
        canAttack = true;
        immortalTime = 0;
        PlayerPrefs.SetInt("Score", 0);
        PlayerPrefs.SetString("CanDie", "true");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            PlayerPrefs.SetString("CanDie", "false");
            capsule.SetActive(true);
            StartCoroutine(immortalTiming());
        }

        xdir = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(xdir * vel, rb.velocity.y);

        if(xdir < 0)
        {
            this.gameObject.transform.localScale = left;
            playeranim.SetBool("isLeft", true);
        }
        else
        {
            this.gameObject.transform.localScale = right;
            playeranim.SetBool("isLeft", false);
        }

        if (rb.velocity.x != 0)
        {
            playeranim.SetBool("running", true);
        }
        else
        {
            playeranim.SetBool("running", false);
        }

        if (Input.GetButton("Jump") && canJump)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpforce);
            playeranim.SetBool("jump", true);
        }
        else
        {
            playeranim.SetBool("jump", false);
        }
        

        if (Input.GetKeyDown(KeyCode.Space) && canAttack)
        {
            if (playeranim.GetCurrentAnimatorStateInfo(0).IsTag("Left"))
            {
                playeranim.SetBool("isLeft", true);
                playeranim.SetBool("attack", true);
                transform.localScale = left;

            }
            else
            {
                playeranim.SetBool("isLeft", false);
                playeranim.SetBool("attack", true);
                transform.localScale = right;
            }
            //Instantiate(bullet, bulletPlace.transform.position, this.gameObject.transform.rotation);
        }
        else
        {
            playeranim.SetBool("attack", false);
        }


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Brain"))
        {
            PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score", 0) + 5);
            Destroy(collision.gameObject);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.collider.CompareTag("Floor"))
        {
            canJump = true;
        }

        if (collision.collider.CompareTag("Enemy"))
        {
            GameController.instance.ShowGameOver();
            Destroy(gameObject);
        }

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Floor"))
        {
            canJump = false;
        }
    }


    IEnumerator immortalTiming()
    {
        yield return new WaitForSeconds(10f);

        capsule.SetActive(false);
        PlayerPrefs.SetString("CanDie", "true");
    }

}
