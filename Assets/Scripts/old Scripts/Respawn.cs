using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{ GameObject Player;
   public  GameObject AutosaveSpot;
    public GameObject PlayerPrefab;
    public GameObject[] Enemies;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        Enemies = GameObject.FindGameObjectsWithTag("Enemy");
    }

    // Update is called once per frame
    void Update()
    {
        Enemies = GameObject.FindGameObjectsWithTag("Enemy");
        Player = GameObject.FindGameObjectWithTag("Player");
       

        if (!Player)
        {
            foreach (GameObject Enemy in Enemies)
            {
                if (Enemy.GetComponent<DeathOnResp>())
                {
                    Enemy.GetComponent<DeathOnResp>().Kill();
                    
                }
                    
            }
        }


    }


    public void RespawnMode()
    {
        
        
            
            Instantiate(PlayerPrefab, AutosaveSpot.transform.position, AutosaveSpot.transform.rotation);
        
        foreach (GameObject Enemy in Enemies)
            {
            if (Enemy.GetComponent<DeathOnResp>())
            {
                Enemy.GetComponent<DeathOnResp>().Kill();
            }
            if (Enemy.GetComponent<EnemyAI>())
            {
                Enemy.GetComponent<EnemyAI>().AfterRespawn();
            }
            if (Enemy.GetComponent<fencing>())
            {
                Enemy.GetComponent<fencing>().active = false;
            }
                if (Enemy.GetComponent<FirePoint>())
                {
                    Enemy.GetComponent<FirePoint>().AfterRespawn();
                Debug.Log("activate");
                }

                if (Enemy.GetComponent<Spawner>())
                {
                    Enemy.GetComponent<Spawner>().AfterRespawn();
                }

            if (Enemy.GetComponent<LifeManager>())
            {
                Enemy.GetComponent<LifeManager>().currentHitpoints= Enemy.GetComponent<LifeManager>().MaxHitpoints;
            }

        }



        FindObjectOfType<PlayerController>().AssignPlayer();
        FindObjectOfType<PlayerController>().RightFacing();
        FindObjectOfType<LifeControl>().AfterRespawn();
    }




}
