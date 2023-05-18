using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinCollection : MonoBehaviour
{
    public GameObject[] coins;
    public int coinsToCollect;
    public GameObject gameObjectToActivate;
    public GameObject gameObjectToActivate2;
    public GameObject gameObjectToDeactivate;
   
    public bool activator;
    public bool activator2;
    public bool deactivator;

    // Start is called before the first frame update
    void Start()
    {
        coinsToCollect = coins.Length;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (coinsToCollect == 0)
        {
            if (activator)
            {
                if(gameObjectToActivate){
                    gameObjectToActivate.SetActive(true); }

            }

            if (activator2)
            {
                if (gameObjectToActivate2)
                {
                    gameObjectToActivate2.SetActive(true);
                }
            }
            if (deactivator)
            {
                if (gameObjectToDeactivate)
                {
                    gameObjectToDeactivate.SetActive(false);
                }
            }
           
            GetComponent<coinCollection>().enabled = false;
        }
    }
    public void CoinCollected()
    {
        if (coinsToCollect > 0)
        {
            coinsToCollect--;
        }
       
    }



}
