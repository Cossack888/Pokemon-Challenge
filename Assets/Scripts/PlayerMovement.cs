using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] InputActionReference movement, attack;


    [Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = .05f;
    [SerializeField] private LayerMask m_WhatIsGround;
    [SerializeField] private Transform m_GroundCheck;
    [SerializeField] float speed = 10f;
    [SerializeField] float k_GroundedRadius = .2f;
    private Vector3 m_Velocity = Vector3.zero;
    Rigidbody2D rb;
    float xMove;
    public float jumpForce = 100f;
    bool jump;
    public bool m_FacingRight;
    public bool m_Grounded;
    float timer;
    Animator anim;
   //public GameObject Hands;
    //public GameObject Idle;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        if (!gameObject.CompareTag("dead"))
        {
            anim.SetBool("FacingRight", m_FacingRight);
            anim.SetFloat("Speed", Mathf.Abs(xMove));
            anim.SetBool("Jump", !m_Grounded);

            xMove = movement.action.ReadValue<Vector2>().x *speed;
            Debug.Log(movement.action.ReadValue<Vector2>().x);

           // xMove = Input.GetAxis("Horizontal") * speed;
            if (xMove > 0 && !m_FacingRight)
            {
                Flip();
            }
            else if (xMove < 0 && m_FacingRight)
            {
                Flip();
            }

            if (Input.GetButtonDown("Jump"))
            {
                Jump();
                
            }
            if (xMove == 0)
            {
                timer += Time.deltaTime;

                if ((Input.GetMouseButton(0) || Input.GetMouseButton(1) || Input.GetMouseButton(2) || Input.GetButton("Jump")))
                {
                 //   Hands.SetActive(true);
                    anim.SetTrigger("Attack1");
                    //Idle.SetActive(false);
                    timer = 0;
                }
                

            }
            if (xMove != 0)
            {
                timer = 0;
               // Hands.SetActive(true);
               // Idle.SetActive(false);
            }
        }
    }
    void FixedUpdate()
    {
        if (!gameObject.CompareTag("dead")){
            if (m_Grounded)
            {
                Vector3 targetVelocity = new Vector2(xMove, rb.velocity.y);

                rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);
            }
            if (!m_Grounded)
            {
                Vector3 targetVelocity = new Vector2(xMove, rb.velocity.y);

                rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);
            }



            if (m_Grounded && jump)
            {

                m_Grounded = false;
                rb.AddForce(new Vector2(0f, jumpForce));
            }

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

    private void Jump()
    {
        jump = true;
        
        StartCoroutine(Jumping());
    }

    IEnumerator Jumping()
    {
        yield return new WaitForSeconds(0.5f);
        jump = false;

    }
    public void Flip()
    {

        m_FacingRight = !m_FacingRight;
        
       // GetComponentInChildren<SpriteRenderer>().flipX = !m_FacingRight;
        transform.Rotate(0f, 180f, 0f);
    }

}
