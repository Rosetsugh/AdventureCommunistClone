using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetSliderSpeedEnter : StateMachineBehaviour
{
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.speed = animator.GetInteger("SliderSpeed");
    }
}
