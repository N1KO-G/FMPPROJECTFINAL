using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerbullet : MonoBehaviour
{

    public float damage;
    devilcard Devilcard;
    
    void Start()
    {
        Devilcard = FindAnyObjectByType<devilcard>();

        Debug.Log(devilcard.devil);
        
    
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
