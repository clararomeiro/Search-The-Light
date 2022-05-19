using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 0;
    private Transform posPlayer;

    private Rigidbody2D rig;

    private bool colliding;

    public bool spot = false;
    public Transform inicioCP;
    public Transform fimCP;

    public int Score;

    public ParticleSystem particula;
    

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        posPlayer = GameObject.FindGameObjectWithTag("Player").transform;
       // olhandoParaEsquerda = true;
    }

    // Update is called once per frame
    void Update()
    {
        /*if(posPlayer.gameObject != null)
        // Vira o inimigo
        {
            transform.position = Vector2.MoveTowards(transform.position, posPlayer.position, speed * Time.deltaTime);
        }*/
        Raycasting();
        Persegue();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            particula.gameObject.SetActive(true);
            Destroy(gameObject, 0.5f);
            GameController.instance.totalScore += Score;
            GameController.instance.UpdateScoreText();
        }
    }

    public void Raycasting()
    {
        Debug.DrawLine(inicioCP.position, fimCP.position, Color.green);
        spot = Physics2D.Linecast(inicioCP.position, fimCP.position, 1 << LayerMask.NameToLayer("Player"));
    }

    public void Persegue()
    {
        if(spot == true && posPlayer.gameObject != null)
        {
            speed = 1;
            transform.position = Vector2.MoveTowards(transform.position, posPlayer.position, speed * Time.deltaTime);
        }
        else
        {
            speed = 0;
        }
    }
}