using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Facing : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<PlayerController>().RightFacing();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
