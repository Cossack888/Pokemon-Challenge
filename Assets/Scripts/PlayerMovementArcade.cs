using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementArcade : MonoBehaviour
{
    Vector2 jumpVector;
    Vector2 movement;
    private GameObject player;
    public Animator animator;
    float horizontalMove = 0f;
    public float moveSpeed = 40f;
    public float m_JumpForce;
    
    public float runSpeed = 1;
    public PhysicsMaterial2D HighFriction;
    public PhysicsMaterial2D LowFriction;
    private Rigidbody2D rb;
    private BoxCollider2D bc;
    private bool m_FacingRight = true;
    private bool weaponDrawn;
    public bool isGrounded=true;



    public void Start()
    {
        player = gameObject;
        rb = player.GetComponent<Rigidbody2D>();
        bc = player.GetComponent<BoxCollider2D>();
      //  jumpVector = new Vector2(0f, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
       // movement.y = Input.GetAxisRaw("Vertical");


        if (Input.GetKey(KeyCode.LeftShift))
        {
            runSpeed = 2;
            animator.SetBool("Running", true);
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            runSpeed = 1;
            animator.SetBool("Running", false);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        /*   if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
           {
               animator.SetBool("isJumping", true);
               rb.AddForce(jumpVector * m_JumpForce, ForceMode2D.Impulse);
               isGrounded = false;
           }
        */
        if (Input.GetButtonDown("Draw") && weaponDrawn == false)
        {
            DrawWeapon();
            weaponDrawn = true;
        }
        else if (weaponDrawn == true && Input.GetButtonDown("Draw"))
        {
            HolsterWeapon();
            weaponDrawn = false;
        }

        if (!m_FacingRight)
        {
            animator.SetBool("FacingLeft", true);
        }
        if (m_FacingRight)
        {
            animator.SetBool("FacingLeft", false);
        }

   

        horizontalMove = Input.GetAxisRaw("Horizontal") * moveSpeed;
        /// player.SetFloat("Speed", Mathf.Abs(horizontalMove));
       animator.SetFloat("Speed", horizontalMove);

    }

    private void FixedUpdate()
    {


        rb.MovePosition(rb.position + movement * moveSpeed * runSpeed * Time.deltaTime);

       animator.SetFloat("Speed", horizontalMove);




        // If the input is moving the player right and the player is facing left...
        if (horizontalMove > 0 && !m_FacingRight)
        {

            // ... flip the player.
            Flip();
        }

        // Otherwise if the input is moving the player left and the player is facing right...
        else if (horizontalMove < 0 && m_FacingRight)
        {
            // ... flip the player.
            Flip();
        }
        // }
    }

    private void Flip()
    {
        // Switch the way the player is labelled as facing.
        m_FacingRight = !m_FacingRight;

        transform.Rotate(0f, 180f, 0f);
    }

    void DrawWeapon()
    {
        animator.SetBool("WeaponDrawn", true);
    }



    void HolsterWeapon()
    {
        animator.SetBool("WeaponDrawn", false);
        weaponDrawn = false;
    }


    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "stairs")
        {
          

            bc.sharedMaterial = HighFriction;
            rb.sharedMaterial = HighFriction;

            if (Input.GetButton("Horizontal"))
            {
                bc.sharedMaterial =LowFriction;
                rb.sharedMaterial = LowFriction;
            }

        }
        if (collision.gameObject.tag == "ground")
        {

            //isGrounded = true;
            bc.sharedMaterial = LowFriction;
            rb.sharedMaterial = LowFriction;
            animator.SetBool("isJumping", false);


        }




    }

    private void Jump()
    {
        Debug.Log("jump");
            rb.AddForce(Vector2.up * m_JumpForce, ForceMode2D.Impulse);
        
    }
 

}
