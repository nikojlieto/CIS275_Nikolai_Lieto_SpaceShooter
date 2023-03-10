using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviourController : MonoBehaviour
{
    //a lot of the destruction code is copied from bullet behaviour
    //as they are destroyed under roughly the same circumstances
    private Camera camera;
    private Vector3 v00;

    void Start()
    {
        //get camera data
        camera = Camera.main;
    }

    void Update()
    {
        checkDestruction();

    }

    void checkDestruction(){
        //destroy at bottom of the screen
        Vector3 v00 = camera.ViewportToWorldPoint(new Vector3(0, 0));
        if(transform.position.y <= v00.y){
            Destroy(gameObject);
        }
        //also destroy if hit by a bullet
    }
       void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag=="Bullet")
        {
            Destroy(gameObject);
        }
    }
}
