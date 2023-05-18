using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdvanceLevel : MonoBehaviour
{
    public GameObject convo;
    string textNow;
    public GameObject nextLevel;
   
    public GameObject menu;

    // Update is called once per frame
    void Update()
    {
        


        if (convo = GameObject.FindGameObjectWithTag("Conversation"))
        {

            convo = GameObject.FindGameObjectWithTag("Conversation");

            textNow = convo.GetComponent<DialogueChanger>().dialog.text;

            if (textNow.Contains("Nastêpny Poziom"))
            {
                EraseMenu();
                nextLevel.SetActive(true);
            }

        }

    }
    public void EraseMenu()
    {
        convo.SetActive(false);
        menu.SetActive(false);
    }
}
