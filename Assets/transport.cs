using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class transport : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Player"))
        {
            if (collision.GetComponent<jumping>())
            {
                collision.GetComponent<jumping>().enabled = false;
            }
            if (collision.GetComponent<runningAway>())
            {
                collision.GetComponent<runningAway>().enabled = true;
            }
            
            collision.transform.position = transform.position;
        }
    }
}
