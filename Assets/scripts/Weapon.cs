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

    public bool FacingRight = true;

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

      public void rotation()
      {
      Debug.Log(guntip.transform.rotation);
       if(aim.transform.rotation.eulerAngles.z > 90  && aim.transform.rotation.eulerAngles.z < 270 && FacingRight)
      {
        guntip.transform.Rotate(0, 0, 180);
        weapon.transform.localScale  = new Vector3(weapon.transform.localScale.x,weapon.transform.localScale.y * -1 ,weapon.transform.localScale.z);
        FacingRight = false;
      }
      if(aim.transform.rotation.eulerAngles.z < 90  && aim.transform.rotation.eulerAngles.z < 270 && !FacingRight || aim.transform.rotation.eulerAngles.z > 90  && aim.transform.rotation.eulerAngles.z > 270 && !FacingRight)
      {
        guntip.transform.Rotate(0, 0, 180);
        weapon.transform.localScale  = new Vector3(weapon.transform.localScale.x,weapon.transform.localScale.y * -1 ,weapon.transform.localScale.z);
        FacingRight = true;
      }
        
    }



     void Update()
    {
        rotation();
    }
  

}
