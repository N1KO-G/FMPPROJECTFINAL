using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderKeywordFilter;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Rendering;

public class enemyfollow : MonoBehaviour
{
    NavMeshAgent agent;

    public float speed;
    public float lineOfSite;
    public float shootingRange;
    public GameObject bullet;
    public GameObject bulletParent;
    private Transform player;
    private float NextFireTime;
    public float fireRate = 1f;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        float distanceFromPlayer = Vector2.Distance(player.position, transform.position);
        if (distanceFromPlayer < lineOfSite && distanceFromPlayer>shootingRange)
        {
        transform.position = Vector2.MoveTowards(this.transform.position,player.position,speed * Time.deltaTime);
        }
        else if (distanceFromPlayer <= shootingRange && NextFireTime < Time.time)
        {
            Instantiate(bullet, bulletParent.transform.position, Quaternion.identity);
            NextFireTime = Time.time +fireRate;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, lineOfSite);
        Gizmos.DrawWireSphere(transform.position, shootingRange);
    }
}
