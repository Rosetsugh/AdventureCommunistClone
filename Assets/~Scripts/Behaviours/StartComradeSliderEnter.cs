using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartComradeSliderEnter : StateMachineBehaviour
{
    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        var countType = animator.GetComponent<SliderCountType>().countType;

        if (countType == "Comrade")
            animator.SetTrigger("MoveSlider");
    }
}
