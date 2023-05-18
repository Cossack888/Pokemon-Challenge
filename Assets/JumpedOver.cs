using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpedOver : MonoBehaviour
{
    public bool jumpedOver;
    public bool nextTarget;
    public GameObject jumper;
    // Start is called before the first frame update
    void Start()
    {
        jumper = GameObject.FindGameObjectWithTag("jumper");
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, jumper.transform.position) < 10 && jumper.transform.position.x < transform.position.x)
        {
            nextTarget = true;
        }
        else
        {
            nextTarget = false;
        }
        if (jumpedOver == true)
        {
            gameObject.SetActive(false);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            jumpedOver = true;

        }
    }
}
