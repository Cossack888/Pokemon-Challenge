using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    AudioSource source;
    [SerializeField]
    AudioClip[] clips;

    public GameObject player;
    private Rigidbody2D rb;
    public PlayerInput input;
    public LifeManager life;
    [SerializeField] float jumpForce;
    [SerializeField] float dashForce=150f;
    [Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = .05f;
    private Vector3 m_Velocity = Vector3.zero;
    [SerializeField] private LayerMask m_WhatIsGround;
    [SerializeField] private Transform m_GroundCheck;
    [SerializeField] float k_GroundedRadius = .2f;
    public bool m_Grounded;
    [SerializeField] float speed = 10f;
    public float xMove;
    public bool m_FacingRight;
    bool jump;
    Animator anim;
    public bool inDialogue;
    DialogueChanger changer;
    bool pc_atttacking;
   public  bool invulnarable;
    public bool dashing;
    public GameObject DeathMenu;
    public GameObject WinMenu;
    public GameObject RestartMenu;
    public float timer;
    public bool blockTimer;
    public bool bomb;
    public PlayerSword sword;
    public int hit=1;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        AssignPlayer();
        input = GetComponent<PlayerInput>();
        anim = player.GetComponent<Animator>();
        changer = FindObjectOfType<DialogueChanger>();
        life = player.GetComponent<LifeManager>();
        sword = FindObjectOfType<PlayerSword>();
        source = player.GetComponent<AudioSource>();
    }

  

    private void Update()
    {
        if (blockTimer)
        {
            timer += Time.deltaTime;
        }
        
        if (timer > 3)
        {
            timer = 0;
            //invulnarable = false;
            anim.SetBool("Block", false);
            blockTimer = false;
            bomb = false;
        }
        player = GameObject.FindGameObjectWithTag("Player");
       
        if (player)
        {
            player = GameObject.FindGameObjectWithTag("Player");
            AssignPlayer();




            if (xMove > 0 && !m_FacingRight)
            {
                Flip();
            }


            else if (xMove < 0 && m_FacingRight)
            {
                Flip();
            }




            anim.SetFloat("Speed", Mathf.Abs(xMove));
            anim.SetBool("Jump", !m_Grounded);
        }
        

    }
    public void Jump(InputAction.CallbackContext context)
    {

        if (player)
        {
            if (context.performed && m_Grounded && !changer.inDialogue)
            {
                rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                m_Grounded = false;
            }
        }
        
        
       
    }
    public void AdjustVolume(InputAction.CallbackContext context)
    {
        if (player)
        {

            if (context.performed)
            {
                GameObject.FindGameObjectWithTag("volume").GetComponent<Slider>().value += (0.05f * context.ReadValue<Vector2>().x);
            }



        }
    }
    public void LightAttack(InputAction.CallbackContext context)
    {
       if(SceneManager.GetActiveScene().buildIndex == 2)
        {
            if (player)
            {
                if (context.performed)
                {
                    anim.SetTrigger("Attack1");
                    anim.SetTrigger("attacking");
                    StartCoroutine(OnCompleteAttackAnimation());
                }
                
                
            }
        }
        else
        {
            if (player)
            {
                if (context.performed)
                {
                    if (hit < 5)
                    {
                        hit++;
                    }
                    else if (hit >= 5)
                    {
                        hit = 1;
                    }
                    anim.SetBool("attacking", true);
                    // ChangeTheSound(0);
                    sword.chooseStance(hit);
                    StartCoroutine(OnCompleteAttackAnimation());
                }
            }
        }
      
       


    }
    public void SwitchConvo(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            DeathMenu = GameObject.FindGameObjectWithTag("DeathMenu");
            WinMenu = GameObject.FindGameObjectWithTag("WinMenu");
            RestartMenu = GameObject.FindGameObjectWithTag("RestartMenu");

            if (changer.inDialogue )
            {
                changer.switchTexts();
            }
            if (DeathMenu)
            {
                if (DeathMenu.activeSelf)
                {

                    GameObject.FindObjectOfType<ActivateRespawn>().Respawn();

                }

            }

            if (RestartMenu)
            {
                if (RestartMenu.activeSelf)
                {

                    GameObject.FindObjectOfType<Restart>().Reset();


                }
            }
            if (WinMenu)
            {
                if (WinMenu.activeSelf)
                {

                    GameObject.FindObjectOfType<NextLevel>().LoadNextLevel();

                }

            }
        }
        

    }

    public void Movement(InputAction.CallbackContext context)
    {
       
           xMove= context.ReadValue<Vector2>().x * speed;
      
       
    }



    public void ChangeMusic(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            FindObjectOfType<changeMusic>().nextClip();
        }

    }
    public void FlipLeft(InputAction.CallbackContext context)
    {
        if (context.performed&&m_FacingRight)
        {
            Flip();
        }

    }
    public void FlipRight(InputAction.CallbackContext context)
    {
        if (context.performed && !m_FacingRight)
        {
            Flip();
        }

    }


    public void Dash(InputAction.CallbackContext context)
    {
        if (player)
        {
            if (context.performed)
            {
                if (m_FacingRight)
                {

                    rb.AddForce(Vector2.right * dashForce, ForceMode2D.Impulse);
                    anim.SetTrigger("Dash");
                    anim.SetBool("attacking", true);
                    dashing = true;
                    invulnarable = true;

                    StartCoroutine(OnCompleteAttackAnimation());
                }
                if (!m_FacingRight)
                {

                    rb.AddForce(Vector2.left * dashForce, ForceMode2D.Impulse);
                    anim.SetTrigger("Dash");
                    anim.SetBool("attacking", true);
                    invulnarable = true;
                    dashing = true;

                    StartCoroutine(OnCompleteAttackAnimation());
                }
            }
        }
       

    }

    public void Lightning(InputAction.CallbackContext context)
    {
        if (player) {

            if (context.performed)
            {
                anim.SetTrigger("Lightning");
            }
        }         
    }
    public void Block(InputAction.CallbackContext context)
    {
        if (player)
        {

            if (context.performed)
            {
                blockTimer = true;
                //invulnarable = true;
                anim.SetBool("Block", true);
                bomb = true;
                var szermierze = FindObjectsOfType<fencing>();

                foreach(var szerm in szermierze)
                {
                    szerm.PlayerBlocking();
                }


            }
            if (context.canceled)
            {
                blockTimer = false;
                anim.SetBool("Block", false);
               // invulnarable = false;
                timer = 0;
                bomb = false;
            }
        }
    }


    private void FixedUpdate()
    {
        if (player)
        {
            
            if (!player.CompareTag("dead"))
            {
                Vector3 targetVelocity = new Vector2(xMove, rb.velocity.y);

                rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);


                Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround);
                for (int i = 0; i < colliders.Length; i++)
                {
                    if (colliders[i].gameObject != gameObject)
                    {
                        m_Grounded = true;

                    }
                }

            }
        }
    }
        

    public void Flip()
    {
        if (player&&!player.CompareTag("dead"))
        {
            m_FacingRight = !m_FacingRight;

            // GetComponentInChildren<SpriteRenderer>().flipX = !m_FacingRight;
            player.transform.Rotate(0f, 180f, 0f);
        }
        
    }
    IEnumerator OnCompleteAttackAnimation()
    {
        yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length);
        invulnarable = false;
        dashing = false;
        
        anim.SetBool("attacking", false);
    }


    public void AssignPlayer()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb = player.GetComponent<Rigidbody2D>();
        anim = player.GetComponent<Animator>();
        life = player.GetComponent<LifeManager>();
        DeathMenu = GameObject.FindGameObjectWithTag("DeathMenu");
        WinMenu = GameObject.FindGameObjectWithTag("WinMenu");
        RestartMenu = GameObject.FindGameObjectWithTag("RestartMenu");
        sword = FindObjectOfType<PlayerSword>();
        if (player.transform.childCount > 0)
        {
            foreach (Transform child in player.transform)
            {
                if (child.CompareTag("GroundCheck"))
                {
                    m_GroundCheck = child;
                }

            }
        }
    }
    public void RightFacing()
    {
        m_FacingRight = true;
    }


    public void ChangeTheSound(int clipIndex) // the index of the sound, 0 for first sound, 1 for the 2nd..etc
    {
        // use one desired logic
        // this will make only one sound to play without interruption
        source.clip = clips[clipIndex];
        source.Play();

        // this will make multiple sound to play with interruption
        // source.PlayOneShot(clips[clipIndex]);
    }
}
