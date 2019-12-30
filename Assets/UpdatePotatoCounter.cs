using TMPro;
using UnityEngine;

public class UpdatePotatoCounter : MonoBehaviour 
{
    private void OnEnable()
    {
        UpdateSliderTextExit.updateNumberOfPotatoes += UpdatePotatoCounterEVH;
    }

    private void OnDisable()
    {
        UpdateSliderTextExit.updateNumberOfPotatoes -= UpdatePotatoCounterEVH;
    }

    private void UpdatePotatoCounterEVH()
    {
        GetComponent<TextMeshProUGUI>().text = LevelSessionData.Singleton.numberOfPotatoes.ToString();

        var multiplier = LevelSessionData.Singleton.numberOfPotatoes / 10;

        if(LevelSessionData.Singleton.numberOfComrades - multiplier > 0)
            MenuManager.Singleton.farmerMultiplier = multiplier;
    }
}