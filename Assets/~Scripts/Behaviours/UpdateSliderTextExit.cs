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
            //animator.GetComponentInChildren<TextMeshProUGUI>().text = LevelSessionData.Singleton.numberOfPotatoes.ToString();
            animator.GetComponentInChildren<TextMeshProUGUI>().text = (3 * LevelSessionData.Singleton.numberOfFarmers).ToString();
            animator.SetFloat("SliderSpeed", LevelSessionData.Singleton.potatoFillSpeed);
        }

        CheckCriteriaToLaunchEvents();
    }

    public delegate void UnlockBuyFarmersButton();
    public static event UnlockBuyFarmersButton unlockBuyFarmersButton;

    public delegate void LockBuyFarmersButton();
    public static event LockBuyFarmersButton lockBuyFarmersButton;

    public delegate void UpdateNumberOfPotatoes();
    public static event UpdateNumberOfPotatoes updateNumberOfPotatoes;

    private void CheckCriteriaToLaunchEvents()
    {
        // Update the text of the main potato counter
        if (updateNumberOfPotatoes != null)
            updateNumberOfPotatoes();

        if (LevelSessionData.Singleton.numberOfPotatoes < 10 * MenuManager.Singleton.farmerMultiplier 
            || LevelSessionData.Singleton.numberOfComrades < 1 * MenuManager.Singleton.farmerMultiplier)
        {
            if (lockBuyFarmersButton != null)
                lockBuyFarmersButton();
        }

        if (LevelSessionData.Singleton.numberOfPotatoes >= 10 * MenuManager.Singleton.farmerMultiplier 
            && LevelSessionData.Singleton.numberOfComrades >= 1 * MenuManager.Singleton.farmerMultiplier)
        {
            if (unlockBuyFarmersButton != null)
                unlockBuyFarmersButton();
        }
    }
}
