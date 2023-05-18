using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombPlanting : MonoBehaviour
{
    public GameObject prompt;
    public GameObject explosion;
    public bool bomb;
    public float timer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (bomb == true)
        {
            timer += Time.deltaTime;
            prompt.SetActive(false);
        }
        if (timer > 3)
        {
            
            gameObject.GetComponent<LifeManager>().mechanical = true;
            gameObject.GetComponent<LifeManager>().Die();
            timer = 0;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            prompt.SetActive(true);
            if (FindObjectOfType<PlayerController>().bomb == true)
            {
                bomb = true;
            }
        }

        

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        prompt.SetActive(false);
    }


}
