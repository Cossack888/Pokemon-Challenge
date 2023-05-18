using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;


public class FollowTarget : MonoBehaviour
{
    public GameObject target;
    public Vector3 targetPos;
    public float speed = 10;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
    }

    // Start is called before the first frame update
    private void Update()
    {
        target = GameObject.FindGameObjectWithTag("Player");
    
        if (target)
        {
            targetPos = target.transform.position;

            float rotZ = Mathf.Atan2(targetPos.y, targetPos.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, rotZ);
            

        }
    }
    


}
