using UnityEngine;

public class PauseGameOnExit : StateMachineBehaviour 
{
    public override void OnStateExit(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        Time.timeScale = 0;
    }
}