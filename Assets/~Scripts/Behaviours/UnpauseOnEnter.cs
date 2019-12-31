using UnityEngine;

public class UnpauseOnEnter : StateMachineBehaviour 
{
    public override void OnStateEnter(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        Time.timeScale = 1;
    }
}