using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class healthmanager : MonoBehaviour
{
    public static event Action OnPlayerDamaged;
    public float health, maxhealth;
   
   void Start()
   {
        
   }
   

   void Death()
   {
    
   }
   
   
 public void TakeDamage(float amount)
   {
        health -= amount;
        OnPlayerDamaged?.Invoke();

        if (health <= 0)
    {
        health = 0;
        Debug.Log("Death");
        SceneManager.LoadScene(0);
    } 
   }
}
