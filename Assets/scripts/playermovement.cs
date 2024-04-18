using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovement : MonoBehaviour
{
    public float movespeed;
    public Rigidbody2D rb;

    private Vector2 moveDirection;

    [Header("dash settings")]
    [SerializeField] float dashspeed = 10f;
    [SerializeField] float dashduration = 1f;
    [SerializeField] float dashcooldown = 1f;
    bool isDashing;
    bool canDash;

    private void Start()
    {
        canDash = true;
    }

    // Update is called once per frame
    void Update()
    {
         if (isDashing)
        {
            return;
        }

         if(Input.GetKeyDown(KeyCode.Space) && canDash) 
        {
            StartCoroutine(dash());
        }

        ProcessInputs();
    }

    void FixedUpdate()
    {
         if (isDashing)
        {
            return;
        }
        Move();
    }

    void ProcessInputs()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector2(moveX, moveY).normalized;

    }

    void Move()
    {
        rb.velocity = new Vector2(moveDirection.x * movespeed, moveDirection.y * movespeed);
    }

    private IEnumerator dash()
    {
        canDash = false;
        isDashing = true;
        rb.velocity = new Vector2(moveDirection.x * dashspeed, moveDirection.y * dashspeed);
        yield return new WaitForSeconds(dashduration);
        isDashing = false;

        yield return new WaitForSeconds(dashcooldown);
        canDash = true;
    }
}
