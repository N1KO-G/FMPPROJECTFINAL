using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Rendering;

public class enemyfollow : MonoBehaviour
{   
    public Rigidbody2D rb;
    NavMeshAgent agent;
    public float health = 5f;
    public float speed;
    public float lineOfSite;
    public float shootingRange;
    public GameObject bullet;
    public GameObject bulletParent;
    private Transform player;
    private float NextFireTime;
    public float fireRate = 1f;
        private Animator animator;
        private Vector2 moveDirectionenemy;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        
        player = GameObject.FindGameObjectWithTag("Player").transform;

         animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        movementinputs();
        
        float distanceFromPlayer = Vector2.Distance(player.position, transform.position);
        if (distanceFromPlayer < lineOfSite && distanceFromPlayer>shootingRange)
        {
        animator.SetBool("isWalking",true);
        animator.SetFloat("Xinput", player.position.x - transform.position.x);
        animator.SetFloat("Yinput", player.position.y - transform.position.y);
        transform.position = Vector2.MoveTowards(this.transform.position,player.position,speed * Time.deltaTime);
        }
        else if (distanceFromPlayer > lineOfSite && shootingRange < distanceFromPlayer)
        {
            animator.SetBool("isWalking", false);
        }
        else if (distanceFromPlayer <= shootingRange && NextFireTime < Time.time)
        {
            Instantiate(bullet, bulletParent.transform.position, Quaternion.identity);
            NextFireTime = Time.time +fireRate;
            
        }
        //else if (rb.velocity.x == 0 || rb.velocity.y == 0)
        //{
        //    animator.SetBool("isWalking", false);
        //}

       
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, lineOfSite);
        Gizmos.DrawWireSphere(transform.position, shootingRange);
    }

    public void TakeDamage(float playeramount)
    {
        health -= playeramount;

        if (health == 0)
        {
            health = 0;
            Destroy(gameObject);
        }
    }

    void FixedUpdate()
    {
        //if (EnemyWalkchecker())
        //{
        //animator.SetBool("isWalking",EnemyWalkchecker());
        //}
        //else
        //{
        //    animator.SetBool("isWalking",false);
        //}
    }

    private bool EnemyWalkchecker()
    {
        if (moveDirectionenemy.x != 0 || moveDirectionenemy.y != 0)
        {
            return true;
        }
        else return false;
    }

    void movementinputs()
    {
        
        //float moveX = rb.velocity.x;
        //float moveY = rb.velocity.y;

        //moveDirectionenemy = new Vector2(moveX, moveY).normalized;
        
        //if (moveDirectionenemy != Vector2.zero)
        //{
        //     animator.SetFloat("Xinput", moveDirectionenemy.x);
        //    animator.SetFloat("Yinput", moveDirectionenemy.y);
       // }
        
    }


}
