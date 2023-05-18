using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopForCutscene : MonoBehaviour
{
    public bool activateCutscene;
    public GameObject cutscene;
    public float timer;
    public float delay = 6;
    public GameObject player;
    public GameObject enemies;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        player = gameObject;
        if (activateCutscene)
        {
            timer += Time.deltaTime;
        }

        if (timer > delay)
        {
            if (player)
            {
                gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
                cutscene.SetActive(false);
                enemies.SetActive(true);
               
            }

        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("cutscene"))
        {
            gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            cutscene.SetActive(true);
            activateCutscene = true;
            collision.gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
