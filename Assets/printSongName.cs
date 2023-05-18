using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class printSongName : MonoBehaviour
{
    public Text songname;
    public changeMusic clips;
    // Start is called before the first frame update
    void Start()
    {
        clips = FindObjectOfType<changeMusic>();
    }

    // Update is called once per frame
    void Update()
    {
        songname.text = clips.clipName;
    }
}
