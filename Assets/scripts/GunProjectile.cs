using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public class GunProjectile : MonoBehaviour
{
    public float speed; 
    
    public GameObject bulletprefab;
    public Transform guntip;
    public GameObject aim;
    public GameObject weapon;

    AudioSource audioSource;
    public AudioClip shoot;
   
   public GameObject bullet;

   public float shootForce, upwardForce;

   public float TimeBetweenShooting, spread, reloadTime, timeBetweenShots;
   public int magazineSize, bulletsPerTap;

   public bool allowButtonHold;

   int bulletsLeft, bulletsShot;

   bool shooting, readyToShoot, reloading;

   
   public Transform attackPoint;

   public GameObject muzzleFlash;
   public TextMeshProUGUI ammunitionDisplay;

   public bool allowInvoke = true;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
   private void Awake()
   {
    bulletsLeft = magazineSize;
    readyToShoot = true;
   }

   private void Update()
   {
    MyInput();

    if (ammunitionDisplay != null)
        ammunitionDisplay.SetText(bulletsLeft / bulletsPerTap + "/" +magazineSize / bulletsPerTap);
   }

   private void MyInput()
   {
    if(allowButtonHold) shooting = Input.GetKey(KeyCode.Mouse0);
    
    else shooting = Input.GetKeyDown(KeyCode.Mouse0);

    if (Input.GetKeyDown(KeyCode.R) && bulletsLeft < magazineSize && !reloading) Reload();

    if(readyToShoot && shooting && !reloading && bulletsLeft <= 0) Reload();



    if (readyToShoot && shooting && !reloading && bulletsLeft >0)
    {
        bulletsShot = 0;

        Shoot();
    }
    }

     private void Shoot()
        {
                  
        GameObject bullet = Instantiate(bulletprefab,guntip.position,guntip.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(guntip.up * speed, ForceMode2D.Impulse);
        
        audioSource.PlayOneShot(shoot, 0.7F);
        
        readyToShoot = false;

        float x = Random.Range(-spread, spread);
        float y = Random.Range(-spread, spread);

        GameObject currentBullet = Instantiate(bullet, attackPoint.position, Quaternion.identity);

        if(muzzleFlash != null)
            Instantiate(muzzleFlash, attackPoint.position, Quaternion.identity);

        bulletsLeft--;
        bulletsShot++;

        if(allowInvoke)
        {
            Invoke("ResetShot", TimeBetweenShooting);
            allowInvoke = false;
        }

        if(bulletsShot < bulletsPerTap && bulletsLeft > 0)
        Invoke("Shoot", timeBetweenShots);


    }

    private void ResetShot()
    {
        readyToShoot = true;
        allowInvoke = true;
    }
    private void Reload()
    {
        reloading = true;
        Invoke("ReloadFinished", reloadTime);

    }

    private void ReloadFinished()
    {
        bulletsLeft = magazineSize;
        reloading = false;
    }

    

}
