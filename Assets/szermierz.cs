using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class szermierz : MonoBehaviour
{
    public int hitNumber;
    public Animator anim;
    public LifeManager manager;
    AnimatorClipInfo[] animatorinfo;
    string current_animation;
    public bool blocked;
    public GameObject cooldownMeter;
    public Text blokuj;
    SpriteRenderer rend;
    public float timeRemaining;
    public CooldownBar cooldownBar;
    public bool active;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        manager = GetComponent<LifeManager>();
        rend = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
       
        animatorinfo = anim.GetCurrentAnimatorClipInfo(0);
        cooldownBar.MaxValue(1);
       
        cooldownBar.SetValue( anim.GetCurrentAnimatorStateInfo(0).normalizedTime);
        timeRemaining = anim.GetCurrentAnimatorStateInfo(0).normalizedTime;
      
           
       
        if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime<0.25)
        {
            blokuj.text = "BLOKUJ!";
        }
        if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.25 && anim.GetCurrentAnimatorStateInfo(0).normalizedTime <0.75)
        {
            blokuj.text = "";
        }
        if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.75)
        {
            blokuj.text = "ODSUÑ SIÊ!";
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            chooseStance(Random.Range(1, 11));
            cooldownMeter.SetActive(true);
            active = true;
        }
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            
            cooldownMeter.SetActive(false);
            active = false;
        }
       
    }

    public void chooseStance(int hit)
    {
        
            switch (hit)
            {
                case 0:

                    anim.SetBool("attacking", false);
                    anim.SetBool("zastawa", false);
                    anim.SetBool("vulnerable", true);
                    manager.invulnarable = false;
                    StartCoroutine(Wait());
                    break;

                case 1:
                    anim.SetTrigger("attack1");
                    anim.SetBool("attacking", true);
                    manager.invulnarable = true;
                    StartCoroutine(OnCompleteAttackAnimation());
                    break;
                case 2:
                    anim.SetTrigger("attack2");
                    anim.SetBool("attacking", true);
                    manager.invulnarable = true;
                    StartCoroutine(OnCompleteAttackAnimation());
                    break;
                case 3:
                    anim.SetTrigger("attack3");
                    anim.SetBool("attacking", true);
                    manager.invulnarable = true;
                    StartCoroutine(OnCompleteAttackAnimation());
                    break;
                case 4:
                    anim.SetTrigger("attack4");
                    anim.SetBool("attacking", true);
                    manager.invulnarable = true;
                    StartCoroutine(OnCompleteAttackAnimation());
                    break;
                case 5:
                    anim.SetTrigger("attack5");
                    anim.SetBool("attacking", true);
                    manager.invulnarable = true;
                    StartCoroutine(OnCompleteAttackAnimation());
                    break;
                case 6:
                    anim.SetTrigger("attack6");
                    anim.SetBool("attacking", true);
                    manager.invulnarable = true;
                    StartCoroutine(OnCompleteAttackAnimation());
                    break;
                case 7:
                    anim.SetTrigger("attack7");
                    anim.SetBool("attacking", true);
                    manager.invulnarable = true;
                    StartCoroutine(OnCompleteAttackAnimation());
                    break;
                case 8:
                    anim.SetTrigger("attack8");
                    anim.SetBool("attacking", true);
                    manager.invulnarable = true;
                    StartCoroutine(OnCompleteAttackAnimation());
                    break;
                case 9:
                    anim.SetTrigger("attack9");
                    anim.SetBool("attacking", true);
                    manager.invulnarable = true;
                    StartCoroutine(OnCompleteAttackAnimation());
                    break;
                case 10:
                    anim.SetTrigger("attack10");
                    anim.SetBool("attacking", true);
                    manager.invulnarable = true;
                    StartCoroutine(OnCompleteAttackAnimation());
                    break;
            case 11:
                anim.SetBool("zastawa", true);
                anim.SetBool("attacking", false);
                manager.invulnarable = true;
                StartCoroutine(OnCompleteAttackAnimation());
                break;


            default:
                    anim.SetBool("zastawa", true);
                    manager.invulnarable = true;

                    break;
            }
        
            

      

    }
    IEnumerator OnCompleteAttackAnimation()
    {
   
        
        yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length);
      

        anim.SetBool("attacking", false);
        anim.SetBool("zastawa", true);
        manager.invulnarable = true;

       // StartCoroutine(Wait2());


            hitNumber = Random.Range(1, 11);
            chooseStance(hitNumber);
     
        anim.SetBool("vulnerable", false);
       
        
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1.5f);
        blocked = false;
       
            hitNumber = Random.Range(1, 11);
            chooseStance(hitNumber);
       
        


    }

    IEnumerator Wait2()
    {
        yield return new WaitForSeconds(1.5f);
        anim.SetBool("zastawa", false);
        hitNumber = Random.Range(1, 11);
        chooseStance(hitNumber);




    }


    public void PlayerBlocking()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime < 0.25)
        {
            blocked = true;
            anim.SetBool("attacking", false);
            hitNumber = 0;
            chooseStance(0);
        }

    }

}
