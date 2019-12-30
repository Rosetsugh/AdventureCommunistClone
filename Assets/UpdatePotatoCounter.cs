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
    }
}