using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CheckIfDead : MonoBehaviour
{
    [SerializeField] GameObject[] EnemiesToCheck;
    [SerializeField]  GameObject ObjectToActivate;
    [SerializeField] GameObject ObjectToActivate2;
    [SerializeField]  GameObject ObjectToDeactivate;
    public bool activate1;
    public bool activate2;
    public bool deactivate1;
    public int x;
    public int x1;
    public int x2;
    public int x3;
    public int x4;
    public int y;
    GameObject[] InactiveObjects;
    public Scene scene;
    // Start is called before the first frame update
    void Start()
    {
        y = EnemiesToCheck.Length;
        Scene scene = SceneManager.GetActiveScene();
        if (scene.buildIndex == 6 || scene.buildIndex == 7)
        {
            InactiveObjects = FindObjectsOfType<GameObject>(true);
            foreach (GameObject objectToActivate in InactiveObjects)
            {
                if (objectToActivate.CompareTag("wygrana"))
                {
                    ObjectToActivate = objectToActivate;
                }
            }


        }


    }

    // Update is called once per frame
    void Update()
    {

        if (EnemiesToCheck.Length==1)
        {
            if (EnemiesToCheck[0] == null)
            {
                x1 = 1;
            }
        }
        if (EnemiesToCheck.Length == 2)
        {
            if (EnemiesToCheck[0] == null)
            {
                x1 = 1;
            }
            if (EnemiesToCheck[1] == null)
            {
                x2 = 1;
            }
        }

        if (EnemiesToCheck.Length == 3)
        {
            if (EnemiesToCheck[0] == null)
            {
                x1 = 1;
            }
            if (EnemiesToCheck[1] == null)
            {
                x2 = 1;
            }

            if (EnemiesToCheck[2] == null)
            {
                x3 = 1;
            }
        }
        if (EnemiesToCheck.Length == 4)
        {
            if (EnemiesToCheck[0] == null)
            {
                x1 = 1;
            }
            if (EnemiesToCheck[1] == null)
            {
                x2 = 1;
            }

            if (EnemiesToCheck[2] == null)
            {
                x3 = 1;
            }
            if (EnemiesToCheck[3] == null)
            {
                x4 = 1;
            }
        }









        /*if (EnemiesToCheck.Length!=0)
        if (EnemiesToCheck.Length==1&& EnemiesToCheck[0])
        {
            if (EnemiesToCheck[0].CompareTag("dead"))
            {
                x1 = 1;
            }
        }
        if (EnemiesToCheck.Length == 2)
        {
            if (EnemiesToCheck[1].CompareTag("dead")&&EnemiesToCheck[1])
            {
                x2 = 1;
            }
        }
        if (EnemiesToCheck.Length == 3&& EnemiesToCheck[2])
        {
            if (EnemiesToCheck[2].CompareTag("dead"))
            {
                x3 = 1;
            }
        }
         */
        x = x1 + x2 + x3 +x4;
       

        if (x == y)
        {
            


            if (activate1&& ObjectToActivate)
            {
                ObjectToActivate.SetActive(true);

                if (ObjectToActivate.GetComponent<BoxCollider2D>())
                {
                    ObjectToActivate.GetComponent<BoxCollider2D>().enabled = true;
                }
                if (ObjectToActivate.GetComponent<Animator>())
                {
                    ObjectToActivate.GetComponent<Animator>().SetTrigger("Activate");
                }



                activate1 = false;
            }
            if (deactivate1&& ObjectToDeactivate)
            {
                ObjectToDeactivate.SetActive(false);
                deactivate1 = false;
            }
            if (activate2 && ObjectToActivate2)
            {
                ObjectToActivate2.SetActive(true);
                if (ObjectToActivate2.GetComponent<BoxCollider2D>())
                {
                    ObjectToActivate2.GetComponent<BoxCollider2D>().enabled = true;
                }
                if (ObjectToActivate2.GetComponent<Animator>())
                {
                    ObjectToActivate2.GetComponent<Animator>().SetTrigger("Activate");
                }
                activate2 = false;
            }

            //GetComponent<CheckIfDead>().enabled = false;

        }
    }
}
