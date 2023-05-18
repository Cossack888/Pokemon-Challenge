using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class AutoSaveCamera : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.FindGameObjectWithTag("AltCam"))
        {
            if (GameObject.FindGameObjectWithTag("AltCam").activeSelf)
            {
                GetComponent<CinemachineVirtualCamera>().m_Follow = GameObject.FindGameObjectWithTag("AltCam").transform;
            }
        }
        else
        {
            GetComponent<CinemachineVirtualCamera>().m_Follow = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectWithTag("AltCam")){
            if (GameObject.FindGameObjectWithTag("AltCam").activeSelf)
            {
                GetComponent<CinemachineVirtualCamera>().m_Follow = GameObject.FindGameObjectWithTag("AltCam").transform;
            }
        }
        else
        {
            if (GameObject.FindGameObjectWithTag("Player"))
            {
                GetComponent<CinemachineVirtualCamera>().m_Follow = GameObject.FindGameObjectWithTag("Player").transform;
            }
        }

        

    }
}
