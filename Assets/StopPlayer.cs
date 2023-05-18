using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopPlayer : MonoBehaviour
{
    public bool activateCutscene;
    public GameObject cutscene;
    public float timer;
    public float delay=10;
    public GameObject player;
    public GameObject enemies;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if (activateCutscene)
        {
            timer += Time.deltaTime;
        }

        if (timer > delay)
        {
            if (player)
            {
                player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
                cutscene.SetActive(false);
                enemies.SetActive(true);
                gameObject.SetActive(false);
            }
            
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;
            activateCutscene = true;
            cutscene.SetActive(true);
            
        }
        else
        {
            collision.gameObject.SetActive(false);
        }
    }
}
