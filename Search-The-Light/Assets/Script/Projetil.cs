using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projetil : MonoBehaviour
{
    [SerializeField]
    private float dist;

    private float time = 1.5f;

    private GameObject Player;
    private float playerDirection;

    //public GameObject boxCollider;

    private void Awake()
    {
        Player = FindObjectOfType<PlayerMovement>().gameObject;
    }
    // Start is called before the first frame update
    void Start()
    {
        //playerDirection = Player.transform.localScale.x;
        if (Player.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsTag("Left"))
        {
            playerDirection = -1;
        }
        else
        {
            playerDirection = 1;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (playerDirection > 0)
        {
            transform.Translate(Vector2.right * dist * Time.deltaTime);

        }
        else
        {
            transform.Translate(Vector2.left * dist * Time.deltaTime);
        }

        Destroy(gameObject, time);
    }
   /* void OnCollisionEnter2D(Collision2D collision)
    {

        if(collision.gameObject.tag == "Object")
        {
            boxCollider.SetActive(false);
        }
    }*/

}
