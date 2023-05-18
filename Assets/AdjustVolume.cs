using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdjustVolume : MonoBehaviour
{
    public AudioSource song;
    public Slider silder;

    private void Start()
    {
        silder = GameObject.FindGameObjectWithTag("volume").GetComponent<Slider>();
        song = GameObject.FindGameObjectWithTag("song").GetComponent<AudioSource>();
        silder.value = 0.2f;
    }

    // Update is called once per frame
    void Update()
    {
        song.volume = silder.value;
    }
}
