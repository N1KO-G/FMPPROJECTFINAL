using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shotgunbullet : MonoBehaviour
{
    public float damage;
    devilcard Devilcard;

    void Start()
    {
        Devilcard = FindObjectOfType<devilcard>();
        if(devilcard.devil)
        {
            damage /= 2;
        }
    }

  void OnCollisionEnter2D(Collision2D collision)
    {
        

        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<enemyfollow>().TakeDamage(damage);
        }
        
            Destroy(this.gameObject);
        
    }


}
