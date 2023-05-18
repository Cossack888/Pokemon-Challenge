using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnEnterActivate : MonoBehaviour
{
    public GameObject ObjectToActivate;
    public GameObject ObjectToActivate2;
    public bool activate;
    public bool activate2;
    public bool deactivate;
    public DialogueChanger changer;
    public int convoNumber;
    public int gameState;
    public bool newConvo;
    // Start is called before the first frame update

    private void Start()
    {
        changer = FindObjectOfType<DialogueChanger>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
            if ((collision.CompareTag("Player") || collision.CompareTag("Player2"))&&activate)
            {
            changer.textNumber = convoNumber;
            changer.ChangeText(convoNumber);
            changer.gameState = gameState;
            ObjectToActivate.SetActive(true);
           

           


               
            }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if ((collision.CompareTag("Player") || collision.CompareTag("Player2")))
        {
            ObjectToActivate.SetActive(false);

            if (activate2)
            {
                if (ObjectToActivate2)
                {
                    ObjectToActivate2.SetActive(true); 
                }

            }
            
            if (deactivate)
            {
                activate = false;
                gameObject.SetActive(false);
            }
            else {
                activate = true;
            }


        }
    }
}
