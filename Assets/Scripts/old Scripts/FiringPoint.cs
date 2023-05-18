using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiringPoint : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    [SerializeField] GameObject lightBullet;
    [SerializeField]
    AudioClip[] clips;
    AudioSource source;
    public bool idle;
    float timer;
    GameObject player;
    public bool canShoot;
    public float delay=1;
    
    void Start()
    {
        source = GetComponent<AudioSource>();
        player = GameObject.FindGameObjectWithTag("Player");
       
       
    }

    

    private void Update()
    {

        
       
        if (player)
        {
            /*if (Input.GetMouseButtonDown(0) && !canShoot)
            {
                coroutine.StartCoroutine(delay);
            }
            if (Input.GetMouseButtonDown(1) && !canShoot)
            {
                coroutine.StartCoroutine(delay);
            }

            */

            if (Input.GetMouseButtonDown(0)&&canShoot)
            {
                Instantiate(bullet, transform.position, transform.rotation);
                ChangeTheSound(0);
                
            }

            if (Input.GetMouseButtonDown(1) && canShoot)
            {

                Instantiate(lightBullet, transform.position, transform.rotation);
                ChangeTheSound(1);
                
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
}
