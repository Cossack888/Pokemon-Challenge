using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Range : MonoBehaviour
{
    public bool inRange;
    public float dist=2;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Range"))
        {
           
            //if(Vector2.Distance(gameObject.transform.position,collision.transform.parent.position)<dist)

            inRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Range"))
        {
            inRange = false;
        }
    }
}
