using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementTest: MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    Vector2 movement;
    public float horizontalMove;
    public Animator player;
    private bool m_FacingRight = true;
    
    public float runSpeed = 1;
    public bool hitByCar=false;
    public CursorMode cursorMode = CursorMode.Auto;
    // Update is called once per frame
    private void Start()
    {
        Cursor.SetCursor(null, Vector2.zero, cursorMode);
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");


        if (Input.GetKey(KeyCode.LeftShift))
        {
            runSpeed = 2;
            player.SetBool("Running", true);
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            runSpeed = 1;
            player.SetBool("Running", false);
        }

        if (Input.GetKey(KeyCode.S) && (Input.GetKeyDown(KeyCode.A)) && !m_FacingRight)
        {
            player.SetBool("WalkingDown", true);
           // player.SetBool("FacingLeft", true);
          //  HolsterWeapon();
            Flip();

            Debug.Log("going left down");
        }
        if (Input.GetKey(KeyCode.S)  && !m_FacingRight)
        {
            player.SetBool("WalkingDown", true);
            //player.SetBool("FacingLeft", true);
           // HolsterWeapon();
            Flip();

            Debug.Log("going  down");
        }

        if (Input.GetKey(KeyCode.W))
        {
            player.SetBool("WalkingUp", true);
            player.SetBool("Running", false);
           // HolsterWeapon();
            

        }
        if (Input.GetKey(KeyCode.W) && (Input.GetKeyDown(KeyCode.D)))
        {
            player.SetBool("WalkingUp", true);
          //  HolsterWeapon();
        }
        if (Input.GetKey(KeyCode.W) && (Input.GetKeyDown(KeyCode.A)))
        {
            player.SetBool("WalkingUp", true);
           // HolsterWeapon();
        }


        if (Input.GetKeyUp(KeyCode.W))
        {
            player.SetBool("WalkingUp", false);
        }
      
    

        if (Input.GetKey(KeyCode.S))
        {
            player.SetBool("WalkingDown", true);
            player.SetBool("FacingLeft", false);
            player.SetBool("Running", false);
          //  HolsterWeapon();
        }

       



        if (Input.GetKeyUp(KeyCode.S))
        {
            player.SetBool("WalkingDown", false);
        }



       /* if (Input.GetButtonDown("Draw") && weaponDrawn == false)
        {
            DrawWeapon();
            weaponDrawn = true;
        }
        else if (weaponDrawn == true && Input.GetButtonDown("Draw"))
        {
            player.SetBool("WeaponDrawn", false);
            weaponDrawn = false;
        }
       */
        if (!m_FacingRight)
        {
            player.SetBool("FacingLeft",true);
        }
        if (m_FacingRight)
        {
            player.SetBool("FacingLeft", false);
        }


      

            horizontalMove = Input.GetAxisRaw("Horizontal") * moveSpeed;
            /// player.SetFloat("Speed", Mathf.Abs(horizontalMove));
            player.SetFloat("Speed", horizontalMove);

    }

    private void FixedUpdate()
    {

       
        
        rb.MovePosition(rb.position + movement * moveSpeed * runSpeed * Time.deltaTime);


        player.SetFloat("Speed", horizontalMove);




        // If the input is moving the player right and the player is facing left...
         if (horizontalMove > 0 && !m_FacingRight) { 

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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Car"))
        {
            player.SetTrigger("death");
            rb.bodyType = RigidbodyType2D.Static;
            hitByCar = true;
        }
    }

    private void Flip()
    {
        // Switch the way the player is labelled as facing.
        m_FacingRight = !m_FacingRight;

        transform.Rotate(0f, 180f, 0f);
    }

    
 


    

}