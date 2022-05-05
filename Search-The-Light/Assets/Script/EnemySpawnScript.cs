using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnScript : MonoBehaviour
{
    public GameObject [] enemies;
    float randX;
    Vector2 whereToSpawn;
    public float spawnRate = 2f;
    float nextSpawn = 0.0f;
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
            randX = Random.Range(-9f, 10.5f);
            int randEnemy = Random.Range(0, enemies.Length);
            whereToSpawn = new Vector2 (randX, transform.position.y);
            Instantiate (enemies[randEnemy], whereToSpawn, Quaternion.identity);
        }
    }
}
