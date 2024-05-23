using System.Collections;

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
    public bool shotgun;
    public TextMeshProUGUI ammunitionDisplay;
    public bool shooting = false;
    weaponpickup Weaponpickup;
    public float spread;
    public AudioClip shootsound;
    public AudioSource AudioSource;
    public AudioClip reloadingsound;
   
    
    
    



    
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

      

       if(shootcooldown <= 0 && bulletamount > 0 && Canshoot && !reloading && !shotgun)
       {
        shooting = true;
        AudioSource.PlayOneShot(shootsound);
        shootcooldown = shootcooldown_time;
        GameObject bullet = Instantiate(bulletprefab,guntip.position,guntip.rotation) ;
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(guntip.up * speed, ForceMode2D.Impulse);
        bulletamount--;
       }
       else if(shootcooldown <= 0 && bulletamount > 0 && Canshoot && !reloading && shotgun)
       {
        shooting = true;
        AudioSource.PlayOneShot(shootsound);
        shootcooldown = shootcooldown_time;
         for(int i = 0; i < 5; i++)
         {GameObject bullet = Instantiate(bulletprefab,guntip.position,guntip.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(ShootVector() * speed, ForceMode2D.Impulse);
         }
        bulletamount--;
       }
       
       
       if (bulletamount == 0 )
       {
        StartCoroutine(Reload());
       }
     
      }

      Vector2 ShootVector()
      {
        Vector2 shootVector = guntip.up;

        shootVector.x += Random.Range(-spread/200, spread /200);
        shootVector.y += Random.Range(-spread / 200, spread /200);

        shootVector = shootVector.normalized;
        return shootVector;
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
        AudioSource.PlayOneShot(reloadingsound);
        
        yield return new  WaitForSeconds(reloadtimer);

        Canshoot = true;
        reloading = false;
        bulletamount = magazinesize;
      }

        
  

}
