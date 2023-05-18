using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    GameObject Player;
    public GameObject DeathScreen;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        if (Player)
        {
            DeathScreen.SetActive(false);
        }
        if (!Player)
        {

            DeathScreen.SetActive(true);

        }

    }

    


}
