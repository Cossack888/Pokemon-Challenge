using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CooldownBar : MonoBehaviour
{


    public Slider slider;
    public float cooldownTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //cooldownTime = FindObjectOfType<szermierz>().timeRemaining;
       // slider.value = cooldownTime;
    }

    public void MaxValue(float cooldownTime)
    {
        slider.maxValue = cooldownTime;
        slider.value = cooldownTime;
    }
    public void SetValue(float cooldownTime)
    {
        slider.value = cooldownTime;
    }
}
