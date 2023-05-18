using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disableCooldownBar : MonoBehaviour
{
    public GameObject Player;
    public GameObject cooldown;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        if (Player){
            if (Vector2.Distance(Player.transform.position, gameObject.transform.position) > 6)
            {
                cooldown.SetActive(false);
            }
            else
            {
                cooldown.SetActive(true);
            }
        }
       
    }
}
