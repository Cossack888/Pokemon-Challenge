using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyActivator : MonoBehaviour
{

    PingPong script1;
    EnemyAI script2;
    EnemyShooter script3;
    Bomber script4;
    MeleeEnemy script5;
    fencing script6;
    FlyingEnemy script7;
    public AudioSource source;
    public Vector2 moveDirection;
    GameObject player;
    Transform target;
    bool respawn;
    bool activated;
    public float range = 10;
    public float meleeDist=2;
    Rigidbody2D rb;
    public bool m_FacingRight;
    public bool shooter;
    public bool melee;
    public bool flying;
    public bool bomber;
    public bool fencing;
    public AudioClip[] clips;
    public bool played;
    // Start is called before the first frame update
    void Start()
    {
        script1 = GetComponent<PingPong>();
        script2 = GetComponent<EnemyAI>();
        script3 = GetComponent<EnemyShooter>();
        script4 = GetComponent<Bomber>();
        script5 = GetComponent<MeleeEnemy>();
        script6 = GetComponent<fencing>();
        script7 = GetComponent<FlyingEnemy>();
        source = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        script1._isFacingRight = m_FacingRight;
       // script2.m_FacingRight = m_FacingRight;
        player = GameObject.FindGameObjectWithTag("Player");

        if (player)  
        {

            target = GameObject.FindGameObjectWithTag("Player").transform;
            if (bomber)
            {
                Vector2 direction = (new Vector3(target.position.x, target.position.y + meleeDist - 0.2f, 0) - transform.position).normalized;
                moveDirection = direction;
            }

            if (!bomber)
            {
                Vector2 direction = (target.position - transform.position).normalized;
                moveDirection = direction;
            }




            if (Vector3.Distance(player.transform.position, transform.position) < 1.5f)
            {
                if (!player.GetComponent<Range>().inRange && player.transform.position.y < transform.position.y+1 )
                {
                    Flip();
                }


            }
            if (script1.isActiveAndEnabled)
            {
                if (rb.velocity.x > 0 && !m_FacingRight)
                {
                    Flip();
                }
                if (rb.velocity.x < 0 && m_FacingRight)
                {
                    Flip();
                }
            }





            else
            {
                if (moveDirection.x > 0 && !m_FacingRight)
                {
                    Flip();
                }
                if (moveDirection.x < 0 && m_FacingRight)
                {
                    Flip();
                }
            }


            target = GameObject.FindGameObjectWithTag("Player").transform;
            if (Vector3.Distance(player.transform.position, transform.position) < range)
            {
               
                activated = true;
                if (source && !played)
                {
                    ChangeTheSound(0);
                    played = true;
                }

            }
            if (Vector3.Distance(player.transform.position, transform.position) > range)
            {

                activated = false;
                

            }


        }

        if (respawn)
        {
            player = GameObject.FindGameObjectWithTag("Player");

            respawn = false;
        }

        if (shooter)
        {
            script1.enabled = !activated;
            script3.enabled = activated;
            
        }
        if (bomber)
        {
            script1.enabled = !activated;
            script4.enabled = activated;
        }
        if (melee)
        {
            script1.enabled = !activated;
            script5.enabled = activated;
            meleeDist = script5.MeleeDist+0.5f;
        }
        if (fencing)
        {
            script1.enabled = !activated;
            script6.enabled = activated;
        }

        if (flying)
        {
            script1.enabled = !activated;
            script7.enabled = activated;
        }

    }

   public void Flip()
    {
        // Switch the way the player is labelled as facing.
        m_FacingRight = !m_FacingRight;

        transform.Rotate(0f, 180f, 0f);

    }


    public void ChangeDirection()
    {
        
            if (m_FacingRight)
            {
                Flip();
            }
            if (!m_FacingRight)
            {
                Flip();
            }
        
        
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
