using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallDown : MonoBehaviour
{
    public Rigidbody2D rb;
    public float timer;
    public GameObject advance;
    public int timesHit;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 5)
        {
            rb.gravityScale = 7;

        }
        if (timesHit>3)
        {
            rb.bodyType = RigidbodyType2D.Static;

        }

       


    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        timesHit++;
    }
}
