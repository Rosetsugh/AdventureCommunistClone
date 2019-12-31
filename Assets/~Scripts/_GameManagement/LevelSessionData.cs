using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelSessionData : MonoBehaviour
{
    public static LevelSessionData Singleton { get; private set; }

    private void Awake()
    {
        if (Singleton == null)
            Singleton = this;

        else
        {
            Debug.LogError("Another Singleton Exits! " + GetType() + ".cs has been removed from the " + name + " Game Object");
            Destroy(this);
        }
    }

    public int numberOfComrades;
    public float comradeFillSpeed = 1;

    public int numberOfFarmers = 1;
    //public float farmerFillSpeed = 0.5f;
    public int farmerMultiplier = 1;

    public int numberOfPotatoes;
    public float potatoFillSpeed = 0.5f;

    public int numberOfCommnues;
    public int communeMultiplier;

    public int numberOfCommuneFarmers;
    public float communeFarmersFillSpeed = 0.5f;

    public Button BuyFarmerButton;

    private void Start()
    {
        numberOfComrades = 0;

        numberOfFarmers = 1;
        farmerMultiplier = 1;

        numberOfPotatoes = 0;

        numberOfCommnues = 1;
        communeMultiplier = 1;
    }

    public void UpdateButtonText()
    {
        if(numberOfPotatoes > 10 * farmerMultiplier && numberOfComrades > 1 * farmerMultiplier)
            BuyFarmerButton.GetComponentInChildren<TextMeshProUGUI>().text = "Buy x" + farmerMultiplier + " Farmers";
    }
}
