using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fencing : MonoBehaviour
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
    public float timer;
    public float delay;
    public float cooldowntime;
    public bool cooldown;
    public bool attacking;
    public GameObject Player;
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
        Player = GameObject.FindGameObjectWithTag("Player");
        
        if (active&&Player)
        {

            if (Vector2.Distance(Player.transform.position, gameObject.transform.position) > 20)
            {
                active = false;
            }
            if (Player.CompareTag("dead"))
            {
                active = false;
                cooldownMeter.SetActive(false);
            }
            animatorinfo = anim.GetCurrentAnimatorClipInfo(0);
            string name = animatorinfo[0].clip.name;


            anim.SetBool("vulnerable", !manager.invulnarable);




            if (!cooldown)
            {
                timer += Time.deltaTime;
                anim.SetBool("zastawa", false);
            }
            
            if (timer > animatorinfo.Length + delay && !cooldown)
            {
                hitNumber = Random.Range(1, 11);
                chooseStance(hitNumber);
                timer = 0;
                cooldown = true;
            }


            if (cooldown)
            {
                cooldowntime += Time.deltaTime;


            }
            if (cooldowntime > 1.5f)
            {


                cooldown = false;
                cooldowntime = 0;
            }
           
            if (name != "idle")
            {

                cooldownBar.MaxValue(1);

                cooldownBar.SetValue(anim.GetCurrentAnimatorStateInfo(0).normalizedTime);
                timeRemaining = anim.GetCurrentAnimatorStateInfo(0).normalizedTime;
                if (animatorinfo[0].clip.name.Contains("seria"))
                {
                    if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime < 0.25)
                    {
                        blokuj.text = "BLOKUJ!";
                    }
                    if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.25 && anim.GetCurrentAnimatorStateInfo(0).normalizedTime < 0.75)
                    {
                        blokuj.text = "";
                    }
                    if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.75)
                    {
                        blokuj.text = "ZAGRO¯ENIE!";
                    }
                }

                else
                {
                    blokuj.text = "BLOKUJ!";
                }
                

            }
            if (name == "idle")
            {


       
                    blokuj.text = "POCZEKAJ!";
                

            }
            if (name == "vulnerable")
            {



                blokuj.text = "ATAKUJ!";


            }

        }
        
            
        
        if(!active)
        {
            chooseStance(20);
            cooldownMeter.SetActive(false);
        }



        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            chooseStance(Random.Range(1, 11));
            cooldownMeter.SetActive(true);
            active = true;
            timer = 0;
            cooldowntime = 0;
        }


    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            chooseStance(20);
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
               
                anim.SetBool("vulnerable", true);
                manager.invulnarable = false;
              //  StartCoroutine(OnCompleteAttackAnimation());
               // StartCoroutine(Wait());
                break;

            case 1:
                anim.SetTrigger("attack1");
                anim.SetBool("attacking", true);
                manager.invulnarable = true;
             //   StartCoroutine(OnCompleteAttackAnimation());
                break;
            case 2:
                anim.SetTrigger("attack2");
                anim.SetBool("attacking", true);
                manager.invulnarable = true;
              //  StartCoroutine(OnCompleteAttackAnimation());
                break;
            case 3:
                anim.SetTrigger("attack3");
                anim.SetBool("attacking", true);
                manager.invulnarable = true;
              //  StartCoroutine(OnCompleteAttackAnimation());
                break;
            case 4:
                anim.SetTrigger("attack4");
                anim.SetBool("attacking", true);
                manager.invulnarable = true;
               // StartCoroutine(OnCompleteAttackAnimation());
                break;
            case 5:
                anim.SetTrigger("attack5");
                anim.SetBool("attacking", true);
                manager.invulnarable = true;
             //   StartCoroutine(OnCompleteAttackAnimation());
                break;
            case 6:
                anim.SetTrigger("attack6");
                anim.SetBool("attacking", true);
                manager.invulnarable = true;
             //   StartCoroutine(OnCompleteAttackAnimation());
                break;
            case 7:
                anim.SetTrigger("attack7");
                anim.SetBool("attacking", true);
                manager.invulnarable = true;
              //  StartCoroutine(OnCompleteAttackAnimation());
                break;
            case 8:
                anim.SetTrigger("attack8");
                anim.SetBool("attacking", true);
                manager.invulnarable = true;
              //  StartCoroutine(OnCompleteAttackAnimation());
                break;
            case 9:
                anim.SetTrigger("attack9");
                anim.SetBool("attacking", true);
                manager.invulnarable = true;
               // StartCoroutine(OnCompleteAttackAnimation());
                break;
            case 10:
                anim.SetTrigger("attack10");
                anim.SetBool("attacking", true);
                manager.invulnarable = true;
               // StartCoroutine(OnCompleteAttackAnimation());
                break;
            case 20:
                anim.SetBool("zastawa",true);
                anim.SetBool("attacking", false);
                manager.invulnarable = true;
                
                break;


            default:
                
                manager.invulnarable = true;

                break;
        }





    }
    IEnumerator OnCompleteAttackAnimation()
    {
        

        yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length);

        StartCoroutine(Wait2());
        chooseStance(20);



    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1.5f);
        blocked = false;
        anim.SetBool("vulnerable", false);
        hitNumber = Random.Range(1, 11);
        chooseStance(hitNumber);




    }
    IEnumerator Wait2()
    {

        yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length);


        hitNumber = Random.Range(1, 11);
        chooseStance(hitNumber);




    }


    public void PlayerBlocking()
    {
        animatorinfo = anim.GetCurrentAnimatorClipInfo(0);
        string name = animatorinfo[0].clip.name;
        if (name.Contains("seria")){
            if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime < 0.35)
            {

                anim.SetBool("attacking", false);
                hitNumber = 0;
                chooseStance(0);
            }
        }
        

    }

}
