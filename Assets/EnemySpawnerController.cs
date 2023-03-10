using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerController : MonoBehaviour
{
    //enemies spawn randomly from the top of the screen
    //anywhere within the screen width
    //enemies move towards the bottom of the screen
    //random spawn amounts
    //random time inbetween spawns
    private float enemySpeed = 2f;
    [SerializeField]
    private GameObject EnemySprite;
    private Camera camera;
    private Vector3 v01;
    private Vector3 v11;
    // Update is called once per frame
    void Start()
    {
        camera = Camera.main;
    }
    
    void Update()
    {
        float delayTime = Random.Range(0f, 1000f);
        if(delayTime>995)
        {
            summonEnemy();
        }
    }

    void summonEnemy(){
        float enemyNum = Random.Range(1f, 4f);
        Vector3 v01 = camera.ViewportToWorldPoint(new Vector3(0, 1));
        Vector3 v11 = camera.ViewportToWorldPoint(new Vector3(1, 1));
        while (enemyNum > 0)
        {
            float enemyRange = v11.x - v01.x;
            float enemyX = Random.Range(v01.x, v11.x);
            Vector3 enemyPos = new Vector3(enemyX, v01.y, 0);
            GameObject newEnemy = Instantiate(EnemySprite, enemyPos, Quaternion.identity);
        if(newEnemy.TryGetComponent(out Rigidbody2D rb)){
                rb.velocity = Vector3.up * -enemySpeed;
            }
        }
    }
}
