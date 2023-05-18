using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateOnEnter : MonoBehaviour
{
    [SerializeField] GameObject objectToActivate;
    [SerializeField] GameObject objectToDeactivate;
    public bool Activator;
    public bool Deactivator;

    private void OnTriggerEnter2D(Collider2D collision)
    {
       if(collision.gameObject.CompareTag("Player")){
            if (Activator&& objectToActivate!=null)
            {
                objectToActivate.SetActive(true);
            }
            if (Deactivator&& objectToDeactivate!=null)
            {
                objectToDeactivate.SetActive(false);
            }
            GetComponent<ActivateOnEnter>().enabled = false;
        }
        
        
    }

}
