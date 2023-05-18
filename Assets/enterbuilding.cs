using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enterbuilding : MonoBehaviour
{
    public GameObject prompt;
    public GameObject wygrana;
    public GameObject explosion;
    public bool bomb;
    public float timer;
    GameObject[] InactiveObjects;
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
            InactiveObjects = FindObjectsOfType<GameObject>(true);
            foreach (GameObject objectToActivate in InactiveObjects)
            {
                if (objectToActivate.CompareTag("wygrana"))
                {

                   wygrana = GameObject.FindGameObjectWithTag("wygrana");
                }

            }
            wygrana.SetActive(true);
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
