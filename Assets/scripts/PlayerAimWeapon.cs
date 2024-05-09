using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;
using UnityEngine.Diagnostics;
using UnityEngine.Rendering;

public class PlayerAimWeapon : MonoBehaviour
{
    private Transform aimTransform;
    private Animator aimAnimator;
    private Transform aimgunEndPointTransform;
    

    public event EventHandler<OnShootEventArgs> OnShoot;
    public class OnShootEventArgs : EventArgs {
        public Vector3 gunEndPointPosition;
        public Vector3 shootPosition;
    }

private void Update()
{
    HandleAiming();
}
    private void HandleShooting()
    {
        if(Input.GetMouseButtonDown(0))
        {

            Vector3 mousePosition = UtilsClass.GetMouseWorldPosition();
            
            

            aimAnimator.Play("AimShoot_Shoot", 0, 0.1f);

            OnShoot?.Invoke(this, new OnShootEventArgs{ 
                gunEndPointPosition = aimgunEndPointTransform.position, shootPosition = mousePosition,});
        }
    }

    private void Awake()
    {
        aimTransform = transform.Find("Aim");
        aimAnimator = aimTransform.GetComponent<Animator>();
        aimgunEndPointTransform = aimTransform.Find("");
    }

    private void HandleAiming()
    {
       Vector3 mousePosition = UtilsClass.GetMouseWorldPosition();
       
       Vector3 aimDirection = (mousePosition - aimTransform.position).normalized;
       float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
       aimTransform.eulerAngles = new Vector3(0,0, angle);
       
       
    }
     
}
