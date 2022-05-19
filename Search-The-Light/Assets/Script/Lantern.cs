using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lantern : MonoBehaviour
{
    private SpriteRenderer sr;
    private CapsuleCollider2D capsule;

    public GameObject lantern;
    public int Special;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        capsule = GetComponent<CapsuleCollider2D>();
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
            lantern.SetActive(true);

            // GameController.instance.UpdateLight();

            Destroy(gameObject, 0.25f);
        }
    }
}
