using TMPro;
using UnityEngine;

public class SliderCountType : MonoBehaviour
{
    [StringDropdown("Comrade", "Farmer", "Potato")]
    public string countType;

    private void Start()
    {
        if (countType == "Comrade")
            GetComponentInChildren<TextMeshProUGUI>().text = LevelSessionData.Singleton.numberOfComrades.ToString();

        if (countType == "Farmer")
            GetComponentInChildren<TextMeshProUGUI>().text = LevelSessionData.Singleton.numberOfFarmers.ToString();

        if (countType == "Potato")
            GetComponentInChildren<TextMeshProUGUI>().text = LevelSessionData.Singleton.numberOfPotatoes.ToString();
    }
}
