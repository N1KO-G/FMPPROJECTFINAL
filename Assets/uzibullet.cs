using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class uzibullet : MonoBehaviour
{
  void OnCollisionEnter2D(Collision2D collision)
    {
        

        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<enemyfollow>().TakeDamage(0.25f);
        }
        
            Destroy(this.gameObject);
        
    }
}
