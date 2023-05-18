using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class runningAway : MonoBehaviour
{
    public AudioClip[] clips;
    public AudioSource source;
    Rigidbody2D rb;
   public Transform target;
    public Transform finalDestination;
    public bool running;
    public bool m_FacingRight;
    public Vector2 moveDirection;
    public float moveSpeed = 20;
    public bool soundPlayed;
    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
        rb.constraints = RigidbodyConstraints2D.FreezePositionX;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (target)
        {
            Vector2 direction = (target.position - transform.position).normalized;
            moveDirection = direction;


            if (moveDirection.x > 0 && !m_FacingRight)
            {
                Flip();
            }
            if (moveDirection.x < 0 && m_FacingRight)
            {
                Flip();
            }
        }
        
    }

    private void FixedUpdate()
    {
        if (target)
        {
            rb.velocity = new Vector2(moveDirection.x, 0) * moveSpeed;
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            running = true;
            target = finalDestination;
            if (!soundPlayed)
            {
                ChangeTheSound(0);
                soundPlayed = true;
            }
    
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
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
