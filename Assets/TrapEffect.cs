using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapEffect : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            gameObject.GetComponent<LifeManager>().TakeDamage(50);
        }
        if (collision.gameObject.CompareTag("Water"))
        {
            gameObject.GetComponent<LifeManager>().Die() ;
        }




    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            gameObject.GetComponent<LifeManager>().TakeDamage(50);
        }
        if (collision.gameObject.CompareTag("Water"))
        {
            gameObject.GetComponent<LifeManager>().Die();
        }

    }
}
