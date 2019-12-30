using UnityEngine;

public class UpdateSliderSpeedEnter : StateMachineBehaviour 
{
    public override void OnStateEnter(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        var countType = animator.GetComponent<SliderCountType>().countType;

        if (countType == "Comrade")
            animator.SetFloat("SliderSpeed", LevelSessionData.Singleton.comradeFillSpeed);


        if (countType == "Potato")
            animator.SetFloat("SliderSpeed", LevelSessionData.Singleton.potatoFillSpeed);
    }
}