using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeDialogueTo : MonoBehaviour
{
    public GameObject Activator;
   public  DialogueChanger changer;
    public int dialogueNumber;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if(Activator.activeSelf)
        {
            changer.ChangeText(dialogueNumber);
            Activator.SetActive(false);
        }
    }
}
