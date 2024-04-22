using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class healthmanager : MonoBehaviour
{

    public float health, maxhealth;
   
   void Start()
   {
        health = maxhealth;
   }
   

   void Death()
   {
    if (health <= 0)
    {
        SceneManager.LoadScene(0);
    } 
   }
   
   
   void TakeDamage()
   {
    
   }
}
