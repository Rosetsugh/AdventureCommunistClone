using TMPro;
using UnityEngine;

public class SliderCountType : MonoBehaviour
{
    private void OnEnable()
    {
        MenuManager.updateSliderText += UpdateSliderTextEVH;
    }

    private void OnDisable()
    {
        MenuManager.updateSliderText -= UpdateSliderTextEVH;
    }

    private void UpdateSliderTextEVH()
    {
        UpdateSliderText();
    }

    [StringDropdown("Comrade", "Farmer", "Potato", "Commune", "CommuneFarmer")]
    public string countType;

    private void Start()
    {
        UpdateSliderText();
    }

    private void UpdateSliderText()
    {
        if (countType == "Comrade")
            GetComponentInChildren<TextMeshProUGUI>().text = LevelSessionData.Singleton.numberOfComrades.ToString();

        if (countType == "Farmer")
            GetComponentInChildren<TextMeshProUGUI>().text = LevelSessionData.Singleton.numberOfFarmers.ToString();

        if (countType == "Potato")
            GetComponentInChildren<TextMeshProUGUI>().text = (LevelSessionData.Singleton.numberOfFarmers * 3).ToString();

        if (countType == "Commune")
            GetComponentInChildren<TextMeshProUGUI>().text = LevelSessionData.Singleton.numberOfCommnues.ToString();

        if (countType == "CommuneFarmer")
            GetComponentInChildren<TextMeshProUGUI>().text = (LevelSessionData.Singleton.numberOfCommuneFarmers * 4).ToString();
    }
}
