using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyAttack : StateMachineBehaviour
{
    public GameObject Player;
    public bool dmgdealt;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    //override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Player = GameObject.FindGameObjectWithTag("Player");


        if (Player && Player.tag != "dead" && animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.95)
        {
            if (Vector2.Distance(animator.transform.position, Player.transform.position) <= animator.GetComponent<EnemyActivator>().meleeDist)
            {
                if (Player.GetComponent<Range>().inRange&&!dmgdealt)
                {
                    Player.GetComponent<LifeManager>().TakeDamage(50);
                    dmgdealt = true;
                }


            }
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        dmgdealt = false;


    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
