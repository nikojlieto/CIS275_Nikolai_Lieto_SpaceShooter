using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerController : MonoBehaviour
{
    private float enemySpeed = 2f;
    [SerializeField]
    private GameObject EnemySprite;
    private Camera camera;
    private Vector3 v01;
    private Vector3 v11;
    private bool summoning;
    // Update is called once per frame
    void Start()
    {
        camera = Camera.main;
    }
    
    void Update()
    {

        if(!summoning)
        {
            summoning = true;
            Invoke("summonEnemy", Random.Range(1f, 4f));
        }
    }

    void summonEnemy(){
        //find range between the sides of the screen
        float enemyNum = Random.Range(2f, 5f);
        Vector3 v01 = camera.ViewportToWorldPoint(new Vector3(0, 1));
        Vector3 v11 = camera.ViewportToWorldPoint(new Vector3(1, 1));
        while (enemyNum > 0)
        {
            float enemyRange = v11.x - v01.x;
            float enemyX = Random.Range(v01.x, v11.x);
            Vector3 enemyPos = new Vector3(enemyX, v01.y+1, 0);
            //initialize and speed up enemies
            GameObject newEnemy = Instantiate(EnemySprite, enemyPos, Quaternion.identity);
            if(newEnemy.TryGetComponent(out Rigidbody2D rb))
            {
                rb.velocity = Vector3.up * -enemySpeed;
            }
            //i forgot this at first and my computer was so upset about it orz
            summoning = false;
            enemyNum--;
        }
    }
}
