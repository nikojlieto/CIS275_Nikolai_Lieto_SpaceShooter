using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BulletBehaviorController : MonoBehaviour
{
    private Camera camera;
    private Vector3 v01;
    public ScoreManager sm;

    void Start()
    {
        //get camera data
        camera = Camera.main;
        sm = FindObjectOfType<ScoreManager>();
        
    }
    void Update()
    {
        checkDestruction();
    }

    void checkDestruction(){
        //destroy when reaching the top of the screen
        Vector3 v01 = camera.ViewportToWorldPoint(new Vector3(0, 1));
        if(transform.position.y >= v01.y){
            Destroy(gameObject);
        }
        
    }
    //destroy when colliding with enemies
    void OnCollisionEnter2D(Collision2D other)
    {
        //tagged all enemy sprites
        if(other.gameObject.tag=="Enemy")
        {
            Destroy(gameObject);
            //increment
            sm.AddScore();
            
        }
    }
}
