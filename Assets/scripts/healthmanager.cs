using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class healthmanager : MonoBehaviour
{
    public static event Action OnPlayerDamaged;
    //public static event Action OnPlayerhealing;
    public float health, maxhealth;
    healthheartbar Healthheartbar;

  public void Start()
  {
    Healthheartbar = FindAnyObjectByType<healthheartbar>();
  }
   
 public void healthregeneration(float amount)
   {
        health += amount;
        maxhealth = health;
        Healthheartbar.DrawHearts();
        
    
   }
   
   
 public void TakeDamage(float amount)
   {
        health -= amount;
        OnPlayerDamaged?.Invoke();

        if (health <= 0)
    {
        health = 0;
        Debug.Log("Death");
        SceneManager.LoadScene(4);
    } 
   }
}
