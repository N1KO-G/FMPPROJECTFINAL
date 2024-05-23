using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class homingbullets : MonoBehaviour
{
    
    public float speed = 5f;
    Transform player;
    playermovement playerMovement;
    public float damage = 1;
    

    
    
    void Start()
    {
        
        playerMovement= FindAnyObjectByType<playermovement>();

        player = GameObject.FindGameObjectWithTag("Player").transform;

        Debug.Log(devilcard.death);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position,player.position, speed * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !playerMovement.isDashing)
        {
            collision.gameObject.GetComponent<healthmanager>().TakeDamage(devilcard.death ? damage * 2 : damage);
        }
        
            Destroy(this.gameObject);
        
    }
}
