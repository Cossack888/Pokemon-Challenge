using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitForCutscene : MonoBehaviour
{
    public float delay;
    float timer;
    Rigidbody2D rb;
    public GameObject Cutscene;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Cutscene.activeSelf)
        {
            timer += Time.deltaTime;
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
            if (timer > delay)
            {
                rb.constraints = RigidbodyConstraints2D.None;
                rb.constraints = RigidbodyConstraints2D.FreezeRotation;
                Cutscene.SetActive(false);
            }

        }
        else
        {
            rb.constraints = RigidbodyConstraints2D.None;
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
    }
}
