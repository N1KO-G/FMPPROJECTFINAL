using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class homingbullets : MonoBehaviour
{
    
    public float speed = 5f;
    Transform player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position,player.position, speed * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        
            Destroy(this.gameObject);
        
    }
}
