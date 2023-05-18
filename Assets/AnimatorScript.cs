using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorScript : MonoBehaviour
{
    LifeManager manager;
    Animator anim;
    private void Start()
    {
        manager = GetComponent<LifeManager>();
        anim = GetComponent<Animator>();
    }

    public void Hurt()
    {
        anim.SetTrigger("hurt");
    }

}
