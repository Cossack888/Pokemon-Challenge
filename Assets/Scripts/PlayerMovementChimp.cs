using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementChimp : MonoBehaviour
{
    Animator anim;
    Rigidbody2D rb;
    [SerializeField] float runSpeed;
    [SerializeField] float jumpPower;
    public Transform characterCont;
    bool facingRight=true;

    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        Vector2 direction = new Vector2(x,y);
        Run(direction);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump(Vector2.up);
        }
        anim.SetFloat("MoveSpeed", Mathf.Abs(direction.x));
        

        if (x > 0){
            
            Vector3 theScale = characterCont.localScale;
            {
                if(!facingRight){
                    theScale.x *= -1;
                    characterCont.localScale = theScale;
                    facingRight = true;

                }
            }
        }

        if (x < 0)
        {

            Vector3 theScale = characterCont.localScale;
            {
                if (facingRight)
                {
                    theScale.x *= -1;
                    characterCont.localScale = theScale;
                    facingRight = false;

                }
            }
        }

       
    }



    void Run(Vector2 dir)
    {
        rb.velocity = new Vector2(dir.x * runSpeed, rb.velocity.y);
    }
    void Jump(Vector2 dir)
    {
        rb.velocity = new Vector2(rb.velocity.x, 0);
        rb.velocity += dir * jumpPower;
        anim.SetTrigger("jump");
    }
}
