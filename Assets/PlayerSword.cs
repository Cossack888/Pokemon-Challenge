using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSword : MonoBehaviour
{
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        

    }

    public void chooseStance(int hit)
    {

        switch (hit)
        {
            case 0:

                break;

            case 1:
                anim.SetTrigger("attack1");
                anim.SetBool("attacking", true);
                
                break;
            case 2:
                anim.SetTrigger("attack2");
                anim.SetBool("attacking", true);
                
                break;
            case 3:
                anim.SetTrigger("attack3");
                anim.SetBool("attacking", true);
                
                break;
            case 4:
                anim.SetTrigger("attack4");
                anim.SetBool("attacking", true);
                break;
            case 5:
                anim.SetTrigger("attack5");
                anim.SetBool("attacking", true);
                
                break;
            case 6:
                anim.SetTrigger("attack6");
                anim.SetBool("attacking", true);
               
                break;
           

            default:

                anim.SetBool("attacking", false);

                break;
        }





    }



}
