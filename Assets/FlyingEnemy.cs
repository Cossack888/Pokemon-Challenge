using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemy : MonoBehaviour
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
    public float DeathDistance = 100;
    public SpriteRenderer EnemySprite;
    public Animator anim;
    public bool MeleeRange;
    public bool ShootRange;

    public bool dashed;

    public bool hasShot;

    // Start is called before the first frame update
    void Start()
    {

        target = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        life = GetComponent<LifeManager>();
        anim = GetComponent<Animator>();
        EnemySprite = GetComponent<SpriteRenderer>();
        activator = GetComponent<EnemyActivator>();
        dist = activator.meleeDist;
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetFloat("Speed", Mathf.Abs(rb.velocity.x));
        player = GameObject.FindGameObjectWithTag("Player");
        if (player)
        {
            target = GameObject.FindGameObjectWithTag("Player").transform;
            Vector2 direction = (new Vector3(target.position.x, target.position.y, 0) - transform.position).normalized;
            moveDirection = direction;
        }

        if (respawn)
        {
            player = GameObject.FindGameObjectWithTag("Player");

            respawn = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Range"))
        {
            if (FindObjectOfType<PlayerController>().dashing)
            {
                dashed = true;


                StartCoroutine(Wait());
            }
        }
    }
    private void FixedUpdate()
    {

        if (!gameObject.CompareTag("dead"))
        {



            if (player)
            {

                MeleeRange = player.GetComponent<Range>().inRange;

                if (Vector3.Distance(player.transform.position, transform.position) < range)
                {
                    activated = true;


                }
                if (Vector3.Distance(player.transform.position, transform.position) > DeathDistance && activated == true && gameObject.CompareTag("Enemy"))
                {
                    gameObject.tag = "dead";

                }




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


