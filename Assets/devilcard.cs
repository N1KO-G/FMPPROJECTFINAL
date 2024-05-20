using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class devilcard : MonoBehaviour
{
    public string sceneName;
    public static bool devil = false;
     public static bool death = false;
    public static bool sword = false;

   public void Start()
   {
     
   }

   public void devilmoney()
   {
        devil = true;
        SceneManager.LoadScene(sceneName);
   }

    public void deathmoney()
   {
        death = true;
        SceneManager.LoadScene(sceneName);
   }

    public void swordmoney()
   {
        sword = true;
        SceneManager.LoadScene(sceneName);
   }
}
