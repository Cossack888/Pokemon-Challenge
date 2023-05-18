using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : StateMachineBehaviour
{
    public GameObject Bullet;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    //override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        GameObject Player = GameObject.FindGameObjectWithTag("Player");
        
         

        if (Vector2.Distance(animator.transform.position, Player.transform.position) < animator.GetComponent<EnemyAI>().range)
        {

           
            foreach (Transform child in animator.transform)
            {
                if (child.CompareTag("FirePoint"))
                {
                    Instantiate(Bullet, child.position, child.rotation); 
                }

            }
            

            }
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
