using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public float speed; 
    
    public GameObject bulletprefab;
    public Transform guntip;
    public GameObject aim;
    public GameObject weapon;
    public bool Canfire;
    public float shootcooldown = 0.2f;

    public void update()
    {
        shootcooldown -= Time.deltaTime;
        
    }

    public void Fire()
    {

       
        GameObject bullet = Instantiate(bulletprefab,guntip.position,guntip.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(guntip.up * speed, ForceMode2D.Impulse);
       
        
        
        
        
    }

    // public void rotation()
    // {
        // if(aim.transform.rotation.eulerAngles.z < 90  || aim.transform.rotation.eulerAngles.z < -90)
        // {
            // guntip.transform.rotation = Quaternion.Euler(guntip.transform.rotation.x, guntip.transform.rotation.y, guntip.transform.rotation.z * -1);
            // weapon.transform.localScale  = new Vector3(weapon.transform.localScale.x,weapon.transform.localScale.y * -1 ,weapon.transform.localScale.z);
// 
        // }
        // 
    // }

    // void Update()
    //{
     //   rotation();
    //}
  

}
