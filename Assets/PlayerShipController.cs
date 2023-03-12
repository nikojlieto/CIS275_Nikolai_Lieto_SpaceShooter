using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShipController : MonoBehaviour
{
    public int currentWeaponIndex = 0;
    [SerializeField]
    public WeaponDatabase weaponDatabase;
    private WeaponType currentWeapon;
    [SerializeField]
    protected float playerSpeed = 10f;
    private float bulletSize = 1f;
    private float bulletSpeed = 20f;
    private Rigidbody2D rb;
    [SerializeField]
    private GameObject BulletSprite;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); 
        currentWeapon = weaponDatabase.weapons[0];
    }

    void FixedUpdate()
    {
        //any substantial behaviors are divided into their own methods
        //movement checks if wasd is used automatically
        Movement();
        //shoot is only called when space is pressed
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
        if(Input.GetKeyDown(KeyCode.C))
        {
            switchWeapons();
        }
    }

    void Movement()
    {
        //basic wasd movement in a 2d space
        if (Input.GetKey(KeyCode.W)){
            transform.position += Vector3.up * playerSpeed * Time.deltaTime;
        } else if (Input.GetKey(KeyCode.A)){
            transform.position += Vector3.right * -playerSpeed * Time.deltaTime;
        } else if (Input.GetKey(KeyCode.S)){
            transform.position += Vector3.up * -playerSpeed * Time.deltaTime;
        } else if (Input.GetKey(KeyCode.D)){
            transform.position += Vector3.right * playerSpeed * Time.deltaTime;
        }
    }

    void Shoot()
    {
        //instantiate and move a bullet upon being called
        GameObject firedBullet = Instantiate(BulletSprite, transform.position +(1*transform.forward), Quaternion.identity);
        firedBullet.transform.localScale = new Vector2(bulletSize, bulletSize);
        if(firedBullet.TryGetComponent(out Rigidbody2D rb)){
                rb.velocity = Vector3.up * bulletSpeed;
            }
    }

    private void switchWeapons()
    {
        if (currentWeaponIndex == 0)
        {
            currentWeapon = weaponDatabase.weapons[1];
            currentWeaponIndex ++;
        } else {
            currentWeapon = weaponDatabase.weapons[0];
            currentWeaponIndex --;
        }
        bulletSpeed = currentWeapon.speed;
        bulletSize = currentWeapon.size;
    }
}
