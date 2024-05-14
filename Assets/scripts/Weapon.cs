using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class Weapon : MonoBehaviour
{
  
    public float speed; 

    
    public GameObject bulletprefab;
    public Transform guntip;
    public GameObject aim;
    public GameObject weapon;
    
    public bool Canfire;
    public float shootcooldown = 0.3f;
    public float shootcooldown_time = 0;
    public float bulletamount;
    public bool FacingRight = true;
    public float magazinesize;

    public bool reloading;
    public bool Canshoot = true;
    public float reloadtimer = 0.5f;
    
    public bool allowButtonHold;
    
    public TextMeshProUGUI ammunitionDisplay;
    public bool shooting = false;
    
    



    
   private void Awake()
   {
   bulletamount = magazinesize;
  }
   
    public void Update()
    {
       if(Input.GetMouseButtonDown(0))
        {
            Fire();
        }
       



      if(shootcooldown > 0) shootcooldown -= Time.deltaTime;
      else
      {
        shootcooldown = 0;
        shooting = false;

        if (Input.GetMouseButton(0) && allowButtonHold)
        {
          Fire();
        }
      }
      
      rotation();

      if (ammunitionDisplay != null)
        ammunitionDisplay.SetText("AMMO = " + bulletamount  + "/" + magazinesize );

      if (bulletamount <= 5 && Input.GetKeyDown(KeyCode.R) && bulletamount > 0 && !shooting)
       {
        Canshoot = false;
        StartCoroutine(Reload());
       }

      
    }

    public void Fire()
    {

      

       if(shootcooldown <= 0 && bulletamount > 0 && Canshoot)
       {
        shooting = true;
        shootcooldown = shootcooldown_time;
        GameObject bullet = Instantiate(bulletprefab,guntip.position,guntip.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(guntip.up * speed, ForceMode2D.Impulse);
        bulletamount--;
       }
       
       
       if (bulletamount == 0 )
       {
        StartCoroutine(Reload());
       }
     
      }
        
    

      public void rotation()
      {
      
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


      IEnumerator Reload()
      {
        reloading = true;
        Canshoot = false;
        
        yield return new  WaitForSeconds(reloadtimer);

        Canshoot = true;
        reloading = false;
        bulletamount = magazinesize;
      }
  

}
