using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShipController : MonoBehaviour
{
    // Start is called before the first frame update
    private float playerSpeed = 10f;
    private Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>(); 
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Movement();
    }

    void Movement()
    {
        if (Input.GetKey(KeyCode.W)){
            Debug.Log("w");
            rb.velocity = new Vector2(0, playerSpeed*5);
        } else if (Input.GetKey(KeyCode.A)){
            rb.velocity = new Vector2(-playerSpeed, 0);
        } else if (Input.GetKey(KeyCode.S)){
            rb.velocity = new Vector2(0, -playerSpeed);
        } else if (Input.GetKey(KeyCode.D)){
            rb.velocity = new Vector2(playerSpeed, 0);
        }
    }
}
