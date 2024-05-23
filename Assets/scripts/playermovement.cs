using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class playermovement : MonoBehaviour
{
    public float movespeed;
    public Rigidbody2D rb;
    public Weapon weapon;
    devilcard Devilcard;
    private Vector2 moveDirection;

    [Header("dash settings")]
    [SerializeField] float dashspeed = 10f;
    [SerializeField] float dashduration = 1f;
    [SerializeField] float dashcooldown = 1f;
    public bool isDashing;
    bool canDash;

    public float steptimer;
    public float timebetweensteps;
    public AudioClip concrete;
    public AudioClip grass;
    public AudioClip dirt;
    public AudioClip gravel;
    public AudioClip wood;
    public AudioClip gore;
    public AudioClip water;
    public AudioClip dashsound;

    private Animator animator;
    public AudioSource AudioSource;

    private void Start()
    {
        canDash = true;
        animator = GetComponent<Animator>();
        if (devilcard.sword)
        {
            movespeed -= 3;
            dashspeed -=4;
        }

        Debug.Log(devilcard.devil);
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

        if (Walkchecker())
        {
        animator.SetBool("IsWalking",Walkchecker());
        
        steptimer -= Time.deltaTime;
        
        if (steptimer < 0)
        {
        PlayFootStepSoundL(concrete);
        steptimer = timebetweensteps;
        }

        }
        else
        {
            animator.SetBool("IsWalking",false);
        }
    }

    void ProcessInputs()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector2(moveX, moveY).normalized;
        if (moveDirection != Vector2.zero)
        {
             animator.SetFloat("Xinput", moveDirection.x);
            animator.SetFloat("Yinput", moveDirection.y);
        }
        
    }

    void Move()
    {
        rb.velocity = new Vector2(moveDirection.x * movespeed, moveDirection.y * movespeed);

    
    }

    private IEnumerator dash()
    {
        
        canDash = false;
        isDashing = true;
        AudioSource.PlayOneShot(dashsound);
        rb.velocity = new Vector2(moveDirection.x * dashspeed, moveDirection.y * dashspeed);
        yield return new WaitForSeconds(dashduration);
        isDashing = false;

        yield return new WaitForSeconds(dashcooldown);
        canDash = true;
        

        if (isDashing)
        {
            gameObject.GetComponent<healthmanager>().TakeDamage(0);
        }
    }

    private bool Walkchecker()
    {
        if (moveDirection.x != 0 || moveDirection.y != 0)
        {
            
            return true; 
        }
        else return false;
    }

     void PlayFootStepSoundL(AudioClip audio)
    {
        AudioSource.pitch = Random.Range(0.8f, 1f);
        AudioSource.PlayOneShot(audio);
    
    }
}
