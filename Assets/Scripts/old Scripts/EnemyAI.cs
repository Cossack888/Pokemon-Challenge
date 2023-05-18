using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyAI : MonoBehaviour
{
    public Vector2 moveDirection;
    public Transform target;
    public Rigidbody2D rb;
    public EnemyActivator activator;
    public float moveSpeed = 10f;
    public float dist = 1;
    public float range = 15;
    public bool attackPosition;
    public GameObject player;
    float timer;
    public bool m_FacingRight = true;
    public LifeManager life;
    public bool jump;
    public bool activated;
    public bool groundEnemy;
    public bool stationaryEnemy;
    public bool respawn;
    public float DeathDistance=100;
    public SpriteRenderer EnemySprite;
    public Animator anim;
    [SerializeField] private LayerMask m_WhatIsGround;
    [SerializeField] private Transform m_GroundCheck;
    [SerializeField] float k_GroundedRadius = .2f;
    public bool m_Grounded;
    public bool dashed;
    public bool shootingEnemy;
    public bool bomber;
    public bool hasShot;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        life = GetComponent<LifeManager>();
        anim = GetComponent<Animator>();
        EnemySprite= GetComponent<SpriteRenderer>();
       activator = GetComponent<EnemyActivator>();



    }
    private void Update()
    {
        anim.SetFloat("Speed", Mathf.Abs(rb.velocity.x));
        player = GameObject.FindGameObjectWithTag("Player");
        if (player)
        {
            target = GameObject.FindGameObjectWithTag("Player").transform;
        }

        if (respawn)
        {
            player = GameObject.FindGameObjectWithTag("Player");
            
            respawn = false;
        }


        if (player)
        {

            if (bomber)
            {
                Vector2 direction = (new Vector3(target.position.x,target.position.y+dist-0.2f,0) - transform.position).normalized;
                moveDirection = direction;
            }

            if (!bomber)
            {
                Vector2 direction = (target.position - transform.position).normalized;
                moveDirection = direction;
            }

        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Range"))
        {
           if(FindObjectOfType<PlayerController>().dashing)
            {
                dashed = true;
               
                
                StartCoroutine(Wait());
            }
        }
    }

    private void FixedUpdate()
    {
       

        if (!gameObject.CompareTag("dead") ){

            Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround);
            for (int i = 0; i < colliders.Length; i++)
            {
                if (colliders[i].gameObject != gameObject)
                {
                    m_Grounded = true;

                }
            }

            if (player)
            {



                if (Vector3.Distance(player.transform.position, transform.position) < range)
                {
                    activated = true;


                }
                if (Vector3.Distance(player.transform.position, transform.position) > DeathDistance && activated == true && gameObject.CompareTag("Enemy"))
                {
                    gameObject.tag = "dead";

                }

                if (groundEnemy && shootingEnemy)
                {
                    

                    if (Vector2.Distance(player.transform.position, transform.position) <range&& Vector2.Distance(player.transform.position, transform.position) >= dist)
                    {



                        if (!dashed&&!hasShot)
                        {
                            rb.velocity = new Vector2(0, 0) * moveSpeed;
                            anim.SetTrigger("shoot");
                            hasShot = true;
                            StartCoroutine(Wait2());
                        }
                        




                    }
                    else if (Vector2.Distance(player.transform.position, transform.position) < dist)
                    {
                        rb.velocity = Vector2.zero;
                        anim.SetTrigger("Attack");
                        
                    }
                }
                
                if (groundEnemy&&!shootingEnemy)
                {
                    if (activated && m_Grounded)
                    {
                        if (Vector2.Distance(player.transform.position, transform.position) >= dist)
                        {
                            if (!dashed)
                            {
                                rb.velocity = new Vector2(moveDirection.x, 0) * moveSpeed;
                            }
                        }

                        else
                        {
                            if (!dashed)
                            {
                                rb.velocity = Vector2.zero;
                                anim.SetTrigger("Attack");
                            }

                        }
                    }
                }
                if (!groundEnemy)
                {
                    if (Vector2.Distance(player.transform.position, transform.position) >= dist)
                    {
                        if (!dashed)
                        {
                            rb.velocity = new Vector2(moveDirection.x, moveDirection.y) * moveSpeed;
                        }
                    }

                    else
                    {
                        if (!dashed)
                        {
                            rb.velocity = Vector2.zero;
                            anim.SetTrigger("Attack");
                        }

                    }
                }
                
            }

        }

    }

    
    IEnumerator Wait()
    {

        yield return new WaitForSeconds(1.5f);
       dashed = false;

    }

    IEnumerator Wait2()
    {

        yield return new WaitForSeconds(2);
       hasShot = false;

    }

    public void AfterRespawn()
    {
        Debug.Log("ActivateAfterResp");
        player = GameObject.FindGameObjectWithTag("Player");
        target = GameObject.FindGameObjectWithTag("Player").transform;
        respawn = true;
        
       
    }
    

}
