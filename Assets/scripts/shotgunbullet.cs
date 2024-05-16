using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shotgunbullet : MonoBehaviour
{
    

  void OnCollisionEnter2D(Collision2D collision)
    {
        

        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<enemyfollow>().TakeDamage(1 / 5);
        }
        
            Destroy(this.gameObject);
        
    }


}
