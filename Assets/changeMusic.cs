using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class changeMusic : MonoBehaviour
{
    AudioSource source;
    public AudioClip[] clips;
    int clipCount;
    public string clipName;
    // Start is called before the first frame update
    void Start()
    {
        clipCount = Random.Range(0,clips.Length+1);
        source = GetComponent<AudioSource>();
        clipName = clips[clipCount].name;

        source.clip = clips[clipCount]; //assign new clip
        source.Play();


    }

    private void Update()
    {
        if (source.isPlaying == false)
        {
            nextClip();
        }
        


    }



    void PlayClip(AudioClip clip)
    {
        source.Stop(); //stop previous clip
        source.clip = clip; //assign new clip
        source.Play();
        clipName = clip.name;

        //CancelInvoke("EventOnEnd"); //in case previously invoked
        Invoke(nameof(EventOnEnd), clip.length); //execute on clip finished
    }

    void EventOnEnd()
    {
        //execute your code here

        if (Application.isEditor) Debug.LogWarning("audio finished!");
    }
    public void nextClip()
    {
        if (clipCount == clips.Length)
        {
            clipCount = 0;
            PlayClip(clips[clipCount]);
        }
        else
        {
            clipCount += 1;
            PlayClip(clips[clipCount]);
        }

       
    }

}
