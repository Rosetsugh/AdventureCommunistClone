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
            LevelSessionData.Singleton.UpdateButtonText("Comrade");
        }

        if (countType == "Potato")
        {
            LevelSessionData.Singleton.numberOfPotatoes += 3 * LevelSessionData.Singleton.numberOfFarmers;
            //animator.GetComponentInChildren<TextMeshProUGUI>().text = LevelSessionData.Singleton.numberOfPotatoes.ToString();
            animator.GetComponentInChildren<TextMeshProUGUI>().text = (3 * LevelSessionData.Singleton.numberOfFarmers).ToString();
            animator.SetFloat("SliderSpeed", LevelSessionData.Singleton.potatoFillSpeed);
        }

        if(countType == "Commune")
        {
            LevelSessionData.Singleton.numberOfFarmers += 4 * LevelSessionData.Singleton.numberOfCommnues;
            //animator.GetComponentInChildren<TextMeshProUGUI>().text = LevelSessionData.Singleton.numberOfCommnues.ToString();
            animator.SetFloat("SliderSpeed", LevelSessionData.Singleton.communeFarmersFillSpeed);
            animator.SetTrigger("MoveSlider");
            LevelSessionData.Singleton.UpdateButtonText("Commune");
        }

        CheckCriteriaToLaunchEvents(countType);
    }

    public delegate void UnlockBuyButton(string countType);
    public static event UnlockBuyButton unlockBuyButton;

    public delegate void LockBuyButton(string countType);
    public static event LockBuyButton lockBuyButton;

    public delegate void UpdateNumberOfPotatoes();
    public static event UpdateNumberOfPotatoes updateNumberOfPotatoes;

    public delegate void UpdateNumberOfFarmers();
    public static event UpdateNumberOfFarmers updateNumberOfFarmers;

    private void CheckCriteriaToLaunchEvents(string countType)
    {
        if (countType == "Potato")
        {
            // Update the text of the main potato counter
            if (updateNumberOfPotatoes != null)
                updateNumberOfPotatoes();


            if (LevelSessionData.Singleton.numberOfPotatoes < 10 * LevelSessionData.Singleton.farmerMultiplier
                || LevelSessionData.Singleton.numberOfComrades < 1 * LevelSessionData.Singleton.farmerMultiplier)
            {
                if (lockBuyButton != null)
                    lockBuyButton("BuyFarmers");
            }

            if (LevelSessionData.Singleton.numberOfPotatoes >= 10 * LevelSessionData.Singleton.farmerMultiplier
                && LevelSessionData.Singleton.numberOfComrades >= 1 * LevelSessionData.Singleton.farmerMultiplier)
            {
                if (unlockBuyButton != null)
                    unlockBuyButton("BuyFarmers");
            }
        }

        if (countType == "Commune")
        {
            Debug.Log("countType Commune");
            if (updateNumberOfFarmers != null)
                updateNumberOfFarmers();

            //if (unlockBuyButton != null)
            //    unlockBuyButton(countType);
        }
    }
}
