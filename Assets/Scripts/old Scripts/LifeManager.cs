using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LifeManager : MonoBehaviour
{
    public int currentHitpoints;
    public int MaxHitpoints = 100;
    public int currentStamina;
    public int MaxStaminaHitpoints = 100;
    public Animator anim;
    public bool isShot;
    public bool hit;
    private Rigidbody2D rb;
    public float timer;
    public GameObject deathEffect;
    bool clearChildren;
    public PlayerController controller;
    public LifeControl control;
    AudioSource source;
    [SerializeField]
    AudioClip[] clips;
    public bool biological;
    public bool mechanical;
    public bool invulnarable;
    // Start is called before the first frame update
    void Start()
    {
        control = FindObjectOfType<LifeControl>();
        currentHitpoints = MaxHitpoints;
        currentStamina = MaxStaminaHitpoints;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        controller = FindObjectOfType<PlayerController>();


        if (gameObject.CompareTag("Player"))
        {
            control.AddLife();
            control.AddLife();
            control.AddLife();
        }
        source = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        
        if (gameObject.tag == "dead")
        {

            timer += Time.deltaTime;
            if (timer > 3)
            {
                Destroy(gameObject);
            }
        }
       
        if (hit)
        {
            GetComponent<SpriteRenderer>().color = new Color(1, 0, 0, 1);
        }
        if (!hit)
        {
            GetComponent<SpriteRenderer>().color = new Color(1,1,1,1);
        }
    }


    public void TakeDamage(int damage)
    {
        if (gameObject.CompareTag("Enemy"))
        {

            if (source)
            {
                ChangeTheSound(0);
            }
            if (!invulnarable)
            {
                currentHitpoints -= damage;
                anim.SetTrigger("hurt");
                hit = true;
                StartCoroutine(Wait());
                if ((currentHitpoints <= 0) && isShot == false)
                {
                    if (rb.gravityScale == 0)
                    {
                        rb.gravityScale = 3;
                    }

                    Die();
                }
            }
            



        }


        else if (gameObject.CompareTag("Player"))
        {
            controller = FindObjectOfType<PlayerController>();
            if (!controller.invulnarable)
            {
                anim.SetTrigger("hurt");
                if (source)
                {
                    ChangeTheSound(0);
                }
                hit = true;
                control.LooseLife();
                StartCoroutine(Wait());
               

            }
        }
    }
    IEnumerator Wait()
    {

        yield return new WaitForSeconds(0.3f);
       hit = false;

    }

    public void Die()
    {

        if (gameObject)
        {
            if (biological) {


                anim.SetTrigger("dead");

                gameObject.tag = "dead";
                rb.gravityScale = -5;
                isShot = true;

                if (gameObject.GetComponent<SpriteRenderer>() != null)
                {
                    gameObject.GetComponent<SpriteRenderer>().enabled = false;
                }
                if (gameObject.GetComponent<BoxCollider2D>() != null)
                {
                    gameObject.GetComponent<BoxCollider2D>().enabled = false;
                }
               

                if (clearChildren == false)
                {
                    foreach (Transform child in transform)
                    {
                        GameObject.Destroy(child.gameObject);
                    }
                    clearChildren = true;
                    Instantiate(deathEffect, transform.position, transform.rotation, gameObject.transform);

                    if (deathEffect.GetComponent<Light2D>())
                    {
                        deathEffect.GetComponent<Light2D>().intensity = 7;
                        deathEffect.GetComponent<Light2D>().pointLightOuterRadius = 5;
                    }
                }


            }
            if (mechanical)
            {


                anim.SetTrigger("dead");

                gameObject.tag = "dead";
                
                isShot = true;

                if (clearChildren == false)
                {
                    foreach (Transform child in transform)
                    {
                        GameObject.Destroy(child.gameObject);
                    }
                    clearChildren = true;
                    Instantiate(deathEffect, transform.position, transform.rotation, gameObject.transform);
                    if (deathEffect.GetComponent<Light2D>())
                    {
                        deathEffect.GetComponent<Light2D>().intensity = 3;
                        deathEffect.GetComponent<Light2D>().pointLightOuterRadius = 2;
                    }
                }


            }





        }

    }

    public void ChangeTheSound(int clipIndex) // the index of the sound, 0 for first sound, 1 for the 2nd..etc
    {
        // use one desired logic
        // this will make only one sound to play without interruption
        source.clip = clips[clipIndex];
        source.Play();

        // this will make multiple sound to play with interruption
        // source.PlayOneShot(clips[clipIndex]);
    }


    public void LightUp()
    {
        Instantiate(deathEffect, transform.position, transform.rotation, gameObject.transform);
       
    }
}


