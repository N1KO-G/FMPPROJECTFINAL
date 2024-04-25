using System.Collections;
using System.Collections.Generic;
using CodeMonkey.Utils;
using UnityEngine;
using UnityEngine.Diagnostics;

public class testing : MonoBehaviour
{
[SerializeField] private PlayerAimWeapon playerAimWeapon;

private void Start()
{
    playerAimWeapon.OnShoot += PlayerAimWeapon_OnShoot;
}

private void PlayerAimWeapon_OnShoot(object sender, PlayerAimWeapon.OnShootEventArgs e)
{
    UtilsClass.ShakeCamera(1f, .2f);
}


}
