using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    private SpriteRenderer sr;
    private CircleCollider2D circle;

    public GameObject collected;
    public int Munition;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        circle = GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Player")
        {
            sr.enabled = false;
            collected.SetActive(true);

            GameController.instance.totalMunition += Munition;

            GameController.instance.UpdateMunitionText();

            if (PlayerMovement.instance.canDie)
            {
                GameController.instance.UpdateLight();
            }

            Destroy(gameObject, 0.25f);
        }
    }
}
