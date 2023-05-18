using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class changeScene : MonoBehaviour
{
    public PlayerInput input;
    float timer;
    public GameObject advance;
    public float delay;
    // Start is called before the first frame update
    void Start()
    {
        input = GetComponent<PlayerInput>();

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
      
        if (timer > delay)
        {
            advance.SetActive(true);
        }


    }
    public void ChangeScene(InputAction.CallbackContext context)
    {


        if (context.performed)
        {
            advance.SetActive(true);
        }
        
    }
}
