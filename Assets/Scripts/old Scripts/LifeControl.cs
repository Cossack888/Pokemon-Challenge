using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeControl : MonoBehaviour
{

    public LifeManager life;
    public GameObject [] hearts;
    public Image heartPrefab;
    public bool respawn;

    // Start is called before the first frame update
    void Start()
    {
        life = GameObject.FindGameObjectWithTag("Player").GetComponent<LifeManager>();
        hearts = GameObject.FindGameObjectsWithTag("Heart");

    }

    // Update is called once per frame
    void Update()
    {
        hearts = GameObject.FindGameObjectsWithTag("Heart");
        if (GameObject.FindGameObjectWithTag("Player"))
        {
            life = GameObject.FindGameObjectWithTag("Player").GetComponent<LifeManager>();
        }
        if (hearts.Length > 3&&respawn)
        {
            LooseLife();
        }
        

        if (Input.GetKeyDown(KeyCode.E))
        {
            AddLife();
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            LooseLife();
        }

        


    }

    public void LooseLife()
    {
        if (hearts.Length > 1)
        {
            hearts = GameObject.FindGameObjectsWithTag("Heart");
            Destroy(hearts[hearts.Length-1]);
        }
        if ((hearts.Length <= 1))
        {
            life.Die();
        }
            
       

    }
    public void AddLife()
    {
        Image heartImage = Instantiate(heartPrefab) as Image;
         heartImage.transform.SetParent(this.transform, false);
        hearts = GameObject.FindGameObjectsWithTag("Heart");
        
    }

    public void AfterRespawn()
    {
        life = GameObject.FindGameObjectWithTag("Player").GetComponent<LifeManager>();
        respawn = true;
        StartCoroutine(Wait());
    }
    IEnumerator Wait()
    {

        yield return new WaitForSeconds(3);
        respawn = false;

    }
}

