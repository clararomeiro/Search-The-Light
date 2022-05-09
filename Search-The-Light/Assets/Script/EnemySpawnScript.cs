using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnScript : MonoBehaviour
{
    public int count = 0;
    public GameObject [] enemies;
    public Transform [] spawnpoint; 

    public float spawnRate = 2f;
    float nextSpawn = 0.0f;

    private bool colliding;
    private Rigidbody2D rig;

    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
         if(Time.time > nextSpawn)
        {
            nextSpawn = Time.time + spawnRate;
            int randEnemy = Random.Range(0, enemies.Length);
            int randSpawnPoint = Random.Range(0, spawnpoint.Length);
            Instantiate (enemies[randEnemy], spawnpoint[randSpawnPoint].position, transform.rotation);
        }
    }

}
