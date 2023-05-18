using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drown : MonoBehaviour
{
    public Rigidbody2D rb;
    public float height;
    public bool kolizja;
    public float gravitacja;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y == height&&!kolizja)
        {
            rb.bodyType = RigidbodyType2D.Static;
        }
        if (transform.position.y > height&&!kolizja)
        {
            rb.bodyType = RigidbodyType2D.Dynamic;
            rb.velocity = new Vector2(0, -0.2f);
        }
        if (transform.position.y < height&&!kolizja)
        {
            rb.bodyType = RigidbodyType2D.Dynamic;
            rb.velocity = new Vector2(0, 1f);
        }


    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player")|| collision.gameObject.CompareTag("Enemy"))
        {
            kolizja = true;


            if (transform.position.y > height)
            {
                rb.bodyType = RigidbodyType2D.Dynamic;
                rb.gravityScale =   1;




            }

            if (transform.position.y <= height)
            {
                rb.bodyType = RigidbodyType2D.Dynamic;
                //rb.gravityScale = -collision.gameObject.GetComponent<Rigidbody2D>().gravityScale - 0.5f;
                rb.velocity = new Vector2(0, -1);



            }

        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Enemy"))
        {
            rb.velocity = new Vector2(0, 2);
            kolizja = false;
        }
    }

    
}
