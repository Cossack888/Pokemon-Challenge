using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueChanger : MonoBehaviour
{
    public Text dialog;
    public string text1;
    public string text2;
    public string text3;
    public string text4;
    public string text5;
    public string text6;
    public string text7;
    public string text8;
    public string text9;
    public string text10;
    public string text11;
    public string text12;
    public string text13;
    public string text14;
    public string text15;
    public string text16;
    public string text17;
    public string text18;
    public string text19;
    public string text20;
    public int textNumber;
    public bool inDialogue;
    public GameObject monologue;
    public int gameState;

    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.FindGameObjectWithTag("dialog"))
        {
            dialog = GameObject.FindGameObjectWithTag("dialog").GetComponent<Text>();
        }
        dialog.text = text1;
        monologue = GameObject.FindGameObjectWithTag("monologue");
    }

    // Update is called once per frame
    void Update()
    {


        if (GameObject.FindGameObjectWithTag("dialog"))
        {
            dialog = GameObject.FindGameObjectWithTag("dialog").GetComponent<Text>();
        }
        

        monologue = GameObject.FindGameObjectWithTag("monologue");
        if (monologue)
        {
            inDialogue = true;
        }
        else
        {
            inDialogue = false;
        }
    }

    public void ChangeText(int textNumberGiven)
    {
        if (GameObject.FindGameObjectWithTag("dialog"))
        {
            dialog = GameObject.FindGameObjectWithTag("dialog").GetComponent<Text>();
        }
        switch (textNumberGiven)
        {
            case 1:
                dialog.text = text1;
                break;
            case 2:
                dialog.text = text2;
                break;
            case 3:
                dialog.text = text3;
                break;
            case 4:
                dialog.text = text4;
                break;
            case 5:
                dialog.text = text5;
                break;
            case 6:
                dialog.text = text6;
                break;
            case 7:
                dialog.text = text7;
                break;
            case 8:
                dialog.text = text8;
                break;
            case 9:
                dialog.text = text9;
                break;
            case 10:
                dialog.text = text10;
                break;
            case 11:
                dialog.text = text11;
                break;
            case 12:
                dialog.text = text12;
                break;
            case 13:
                dialog.text = text13;
                break;
            case 14:
                dialog.text = text14;
                break;
            case 15:
                dialog.text = text15;
                break;

            case 16:
                dialog.text = text16;
                break;

            case 17:
                dialog.text = text17;
                break;

            case 18:
                dialog.text = text18;
                break;

            case 19:
                dialog.text = text19;
                break;
            case 20:
                dialog.text = text20;
                break;

            default:
                dialog.text = "";
                break;
        }
    }
    public void switchTexts()
    {
        if (inDialogue)
        {
            if (textNumber < gameState)
            {
                textNumber += 1;
                ChangeText(textNumber);
            }
            if (textNumber == gameState)
            {

                monologue.SetActive(false);
            }

        }
       
    }



    




}
