using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class uzibullet : MonoBehaviour
{
    public float damage;
    devilcard Devilcard;

    void Start ()
    {
        Devilcard = FindAnyObjectByType<devilcard>();
      
    }
  void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<enemyfollow>().TakeDamage(devilcard.devil ? damage/2 : damage);
        }
        
            Destroy(this.gameObject);
        
    }
}
