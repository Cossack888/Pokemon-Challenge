using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject spawnableObject;
    public Transform spawnPoint;
    float timer;
    public float delay = 2;
    GameObject player;
    public float dist = 10;
   public  bool activated;
    bool spawned;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if (player)
        {
            if (Vector3.Distance(transform.position,player.transform.position) < dist)
            {
                activated = true;
                //Debug.Log(Vector3.Distance(transform.position, player.transform.position));

            }
            else
            {
                activated = false;
            }
            if (activated)
            {
                timer += Time.deltaTime;
                if (timer > delay && spawned== false && !gameObject.CompareTag("dead"))
                {
                    Instantiate(spawnableObject, spawnPoint.position, transform.rotation);
                   
                    spawned = true;
                    StartCoroutine(Wait());
                    timer = 0;
                }
            }


        } 
            
        
            
    }
    IEnumerator Wait()
    {

        yield return new WaitForSeconds(delay);
        spawned = false;

    }
    public void AfterRespawn()
    {

        player = GameObject.FindGameObjectWithTag("Player");




    }
}
