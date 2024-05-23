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
     death = false;
     sword = false;
     if (devil == false && death == false && sword == false)
     {
        devil = true;
        SceneManager.LoadScene(sceneName);
     }
        else devil = false;
        
   }

    public void deathmoney()
   {
     devil = false;
     sword = false;
     if (devil == false && death == false && sword == false)
     {
        death = true;
        SceneManager.LoadScene(sceneName);
   }
        else death = false;
   }
     public void swordmoney()
   {
     devil = false;
     death = false;

     if (devil == false && death == false && sword == false)
     {
        sword = true;
        SceneManager.LoadScene(sceneName);
   }
   else sword = false;
   }
}
