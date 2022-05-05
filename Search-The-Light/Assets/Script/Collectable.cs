<<<<<<< Updated upstream:Search-The-Light/Assets/Script/coletavel.cs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coletavel : MonoBehaviour
{
    private SpriteRenderer sr;
    private CircleCollider2D circle;
    public GameObject collected;

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
            circle.enabled = false;
            collected.SetActive(true);

            Destroy(gameObject, 0.25f);
        }
    }
}
=======
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    private SpriteRenderer sr;
    private CircleCollider2D circle;

    public GameObject collected;
    public int Score;

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

            GameController.instance.totalScore += Score;

            GameController.instance.UpdateScoreText();
            
            Destroy(gameObject, 0.25f);
        }
    }
}
>>>>>>> Stashed changes:Search-The-Light/Assets/Script/Collectable.cs
