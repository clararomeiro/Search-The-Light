using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement instance;

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

    private int bulletqtd;

    public AudioClip walkSound;
    public AudioClip jumpSound;
    public AudioSource fxSource;

    public bool canDie;


    // Start is called before the first frame update
    void Start()
    {
        if(instance == null) instance = this;
        PlayerPrefs.SetInt("EnemyKilled", 0);
        right = transform.localScale;
        left = transform.localScale;
        left.x *= -1;
        PlayerPrefs.SetInt("bullet", 0);
        PlayerPrefs.SetString("CanDie", "true");
        canDie = true;
    }

    // Update is called once per frame
    void Update()
    {
        bulletqtd = PlayerPrefs.GetInt("bullet");


        xdir = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(xdir * vel, rb.velocity.y);

        if (xdir < 0)
        {
            this.gameObject.transform.localScale = left;
            playeranim.SetBool("isLeft", true);
        }
        else
        {
            this.gameObject.transform.localScale = right;
            playeranim.SetBool("isLeft", false);
        }


        if (Input.GetButton("Jump") && canJump)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpforce);
            playeranim.SetBool("jump", true);
            fxSource.clip = jumpSound;
            fxSource.Play();
        }
        else
        {
            playeranim.SetBool("jump", false);
        }


        if (rb.velocity.x != 0 )
        {
            playeranim.SetBool("running", true);
            if(Input.GetButton("Jump") && canJump)
            {
                fxSource.clip = jumpSound;
            }
            else
            {
                fxSource.clip = walkSound;
            }
            if (!fxSource.isPlaying)
            {
                fxSource.Play();
            }
        }
        else
        {
            playeranim.SetBool("running", false);
            {
                if(fxSource.clip == walkSound)
                {
                    fxSource.Stop();
                }
            }
        }


        if (Input.GetKeyDown(KeyCode.Space) && PlayerPrefs.GetInt("bullet") >= 1 && !GrabObject.instance.isGrabbing)
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
            Instantiate(bullet, bulletPlace.transform.position, this.gameObject.transform.rotation);

            if (canDie)
            {
                PlayerPrefs.SetInt("bullet", bulletqtd - 1);
                GameController.instance.totalMunition -= 1;
                GameController.instance.UpdateMunitionText();
                GameController.instance.UpdateLight();
            }
        }
        else
        {
            playeranim.SetBool("attack", false);
        }


    }

    private void OnCollisionStay2D(Collision2D collision)
    {

        if (collision.collider.CompareTag("Floor") || collision.collider.CompareTag("Object"))
        {
            canJump = true;
        }

        if (collision.collider.CompareTag("Enemy"))
        {
            if (canDie)
            {
                GameController.instance.ShowGameOver();
                Destroy(gameObject);
            }
        }

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Floor") || collision.collider.CompareTag("Object"))
        {
            canJump = false;
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {

        Debug.Log("trigger");
        if (collision.CompareTag("EndLevel"))
        {
            Debug.Log("endlevel");
            GameController.instance.ShowGameOver();
        }

        if (collision.CompareTag("Lantern"))
        {
            specialAction();
        }

        if (collision.CompareTag("NextLevel"))
        {
            SceneManager.LoadScene("CityStory");
        }

        if (collision.CompareTag("Finish"))
        {
           SceneManager.LoadScene("FinalStory");
        }
    }

    public void specialAction()
    {
        StartCoroutine(specialActionCoroutine());
    }

    IEnumerator specialActionCoroutine()
    {
        canDie = false;
        GameController.instance.UpdateLightLantern(true);

        yield return new WaitForSeconds(10);

        canDie = true;
        GameController.instance.UpdateLightLantern(false);

    }


}
