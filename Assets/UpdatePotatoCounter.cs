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
    }
}