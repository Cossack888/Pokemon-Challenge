using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collect : MonoBehaviour
{ DataStorage storage;
    public bool AdvanceCoin;

    private void Start()
    {
        storage= FindObjectOfType<DataStorage>();
    }
    public void OnTriggerEnter2D(Collider2D collision)

    {

        if (collision.CompareTag("Player")|| collision.CompareTag("Player2")){

            storage.coins += 1;
            

            if (AdvanceCoin)
            {
                var CC = FindObjectsOfType<coinCollection>();
                    foreach(coinCollection coin in CC)
                {
                    if (coin.isActiveAndEnabled)
                    {
                        coin.CoinCollected();
                    }
                }
                    
                    
                    
            }



            Destroy(gameObject);
        }
    }
}
