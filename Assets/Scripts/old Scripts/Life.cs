using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour
{
    public int currentHitpoints;
    public int MaxHitpoints = 100;
    public int currentStamina;
    public int MaxStaminaHitpoints = 100;
    public Animator anim;
    public bool isShot;
    private Rigidbody2D rb;



    public void Start()
    {
        currentHitpoints = MaxHitpoints;
        currentStamina = MaxStaminaHitpoints;
        rb = GetComponent<Rigidbody2D>();
    }


    public void ZappDamage(int zappPower)
    {
        currentStamina -= zappPower;
        if ((currentStamina <= 0) && isShot == false)
        {
            if (rb.gravityScale == 0)
            {
                rb.gravityScale = 3;
            }

            Zapped();
        }

    }



    public void TakeDamage(int damage)
    {
        currentHitpoints -= damage;


        if ((currentHitpoints <= 0) && isShot == false)
        {
            if (rb.gravityScale == 0)
            {
                rb.gravityScale = 3;
            }

            Die();
        }


    }


    public void Die()
    {

        if (gameObject)
        {
            anim.SetTrigger("isShot");

            gameObject.tag = "dead";
            isShot = true;

            MonoBehaviour[] scripts = gameObject.GetComponents<MonoBehaviour>();
            foreach (MonoBehaviour script in scripts)
            {
                script.enabled = false;
            }
            foreach (Transform child in transform)
            {
                GameObject.Destroy(child.gameObject);
            }

            gameObject.layer = 3;

        }

    }

    public void Zapped()
    {

        if (gameObject)
        {

            anim.SetTrigger("isZapped");

            gameObject.tag = "dead";
            isShot = true;

            MonoBehaviour[] scripts = gameObject.GetComponents<MonoBehaviour>();
            foreach (MonoBehaviour script in scripts)
            {
                script.enabled = false;
            }
            foreach (Transform child in transform)
            {
                GameObject.Destroy(child.gameObject);
            }

            gameObject.layer = 3;


        }

    }





}