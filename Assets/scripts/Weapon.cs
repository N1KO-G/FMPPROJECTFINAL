using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public float speed; 
    
    public GameObject bulletprefab;
    public Transform guntip;
  
    public void Fire()
    {
        GameObject bullet = Instantiate(bulletprefab,guntip.position,guntip.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(guntip.up * speed, ForceMode2D.Impulse);
    }
  

}
