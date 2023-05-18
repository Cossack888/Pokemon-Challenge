using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    public GameObject LoadingScreen;
    public float transitionTime = 3f;
    public GameObject changeLevels;
    // public GameObject player;
    public Scene scene;
    GameObject[] InactiveObjects;


    void Start()
    {
        scene = SceneManager.GetActiveScene();
        Debug.Log("Active Scene is '" + scene.name + "'.");

       
       
            InactiveObjects = FindObjectsOfType<GameObject>(true);
            foreach (GameObject objectToActivate in InactiveObjects)
            {
                if (objectToActivate.CompareTag("wygrana"))
                {

                    changeLevels = GameObject.FindGameObjectWithTag("wygrana");
                }

            }

    }


    // Update is called once per frame
    void Update()
    {
        if (changeLevels)
        {
            if (changeLevels.activeSelf)
            {
                LoadNextLevel();
                changeLevels.SetActive(false);
            }
        }
            
 
    }

    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
        //player.SetActive(false);
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        LoadingScreen.SetActive(true);
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(levelIndex);
    }
}
