using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpdateSliderTextExit : StateMachineBehaviour
{
    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        var countType = animator.GetComponent<SliderCountType>().countType;

        if (countType == "Comrade")
        {
            LevelSessionData.Singleton.numberOfComrades++;
            animator.GetComponentInChildren<TextMeshProUGUI>().text = LevelSessionData.Singleton.numberOfComrades.ToString();
            animator.SetFloat("SliderSpeed", LevelSessionData.Singleton.comradeFillSpeed);
            animator.SetTrigger("MoveSlider");
        }

        if (countType == "Potato")
        {
            LevelSessionData.Singleton.numberOfPotatoes += 3 * LevelSessionData.Singleton.numberOfFarmers;
            animator.GetComponentInChildren<TextMeshProUGUI>().text = LevelSessionData.Singleton.numberOfPotatoes.ToString();
            animator.SetFloat("SliderSpeed", LevelSessionData.Singleton.potatoFillSpeed);
        }

        CheckCriteriaToLaunchEvents();
    }

    public delegate void UnlockBuyFarmersButton();
    public static event UnlockBuyFarmersButton unlockBuyFarmersButton;

    public delegate void LockBuyFarmersButton();
    public static event LockBuyFarmersButton lockBuyFarmersButton;

    private void CheckCriteriaToLaunchEvents()
    {
        Debug.Log("got here");
        if (LevelSessionData.Singleton.numberOfPotatoes < 10 && LevelSessionData.Singleton.numberOfComrades < 1)
        {
            Debug.Log("got here");
            if (lockBuyFarmersButton != null)
                lockBuyFarmersButton();
        }

        if (LevelSessionData.Singleton.numberOfPotatoes >= 10 && LevelSessionData.Singleton.numberOfComrades >= 1)
        {
            if (unlockBuyFarmersButton != null)
                unlockBuyFarmersButton();
        }
    }
}
