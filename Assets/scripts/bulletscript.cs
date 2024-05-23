using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletscript : MonoBehaviour
{
    GameObject target;
    public float speed; 
    Rigidbody2D bulletRB;
    playermovement playerMovement;
    public float damage = 1;
    devilcard Devilcard;
    // Start is called before the first frame update
    void Start()
    {
        Devilcard = FindObjectOfType<devilcard>();
        playerMovement= FindAnyObjectByType<playermovement>();
        bulletRB = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player");
        Vector2 moveDir = (target.transform.position - transform.position).normalized * speed;
        bulletRB.velocity = new Vector2(moveDir.x, moveDir.y);
        Destroy(this.gameObject, 2);
        Debug.Log(devilcard.death);


    }

    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            if (!playerMovement.isDashing)
            collision.gameObject.GetComponent<healthmanager>().TakeDamage(devilcard.death ? damage * 2 : damage);
        }
        
            Destroy(this.gameObject);
        
    }

   




 
}
