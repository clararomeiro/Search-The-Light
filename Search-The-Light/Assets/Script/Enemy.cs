using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    private Transform posPlayer;

    private Rigidbody2D rig;

    private bool colliding;
    

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        posPlayer = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(posPlayer.gameObject != null)
        // Vira o inimigo
        {
            transform.position = Vector2.MoveTowards(transform.position, posPlayer.position, speed * Time.deltaTime);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {

        if(collision.gameObject.tag == "Bullet")
        {
            Destroy(gameObject, 0.25f);
            /*GameController.instance.totalScore += Score;
            GameController.instance.UpdateScoreText();*/
        }
        
    
    }


}