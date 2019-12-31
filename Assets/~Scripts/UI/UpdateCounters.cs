using TMPro;
using UnityEngine;

public class UpdateCounters : MonoBehaviour
{
    private void OnEnable()
    {
        UpdateSliderTextExit.updateNumberOfPotatoes += UpdatePotatoCounterEVH;
        UpdateSliderTextExit.updateNumberOfFarmers += UpdateFarmerCounterEVH;
    }

    private void OnDisable()
    {
        UpdateSliderTextExit.updateNumberOfPotatoes -= UpdatePotatoCounterEVH;
        UpdateSliderTextExit.updateNumberOfFarmers -= UpdateFarmerCounterEVH;
    }

    public delegate void UpdateButtonText(int farmerMultiplyer);
    public static event UpdateButtonText updateButtonText;

    private void UpdatePotatoCounterEVH()
    {
        GetComponent<TextMeshProUGUI>().text = LevelSessionData.Singleton.numberOfPotatoes.ToString();

        var multiplier = LevelSessionData.Singleton.numberOfPotatoes / 10;

        if (multiplier < 1)
            return;

        if (LevelSessionData.Singleton.numberOfComrades - multiplier > 0)
        {
            LevelSessionData.Singleton.farmerMultiplier = multiplier;

            if (updateButtonText != null)
                updateButtonText(multiplier);
        }

        // Reset multiplier
        else
        {
            LevelSessionData.Singleton.farmerMultiplier = LevelSessionData.Singleton.numberOfComrades;

            if (updateButtonText != null)
                updateButtonText(LevelSessionData.Singleton.numberOfComrades);
        }
    }

    private void UpdateFarmerCounterEVH()
    {
        GetComponent<TextMeshProUGUI>().text = LevelSessionData.Singleton.numberOfFarmers.ToString();
    }
}