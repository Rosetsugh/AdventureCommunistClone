﻿using TMPro;
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

    public TextMeshProUGUI potatoSliderText;

    [SerializeField, CustomProperty("NumberOfFarmers")]
    private int _numberOfFarmers;
    public int NumberOfFarmers
    {
        get { return _numberOfFarmers; }
        set
        {
            _numberOfFarmers = value;
            potatoSliderText.text = (3 * NumberOfFarmers).ToString();
        }
    }

    //public float farmerFillSpeed = 0.5f;
    public int farmerMultiplier = 1;

    public TextMeshProUGUI totalPotatoesText;

    [SerializeField, CustomProperty("NumberOfFarmers")]
    private int _numberOfPotatoes;
    public int NumberOfPotatoes
    {
        get { return _numberOfPotatoes; }
        set
        {
            _numberOfPotatoes = value;
            totalPotatoesText.text = NumberOfPotatoes.ToString();
        }
    }
    public float potatoFillSpeed = 0.5f;

    public int numberOfCommnues;
    public int communeMultiplier;

    public int numberOfCommuneFarmers;
    public float communeFarmersFillSpeed = 0.5f;

    public Button BuyFarmerButton;

    private void Start()
    {
        numberOfComrades = 0;

        NumberOfFarmers = 1;
        farmerMultiplier = 1;

        NumberOfPotatoes = 0;

        numberOfCommnues = 1;
        communeMultiplier = 1;
    }

    public void UpdateButtonText(string countType)
    {
        if (countType == "Commrade")
        {
            if (NumberOfPotatoes > 10 * farmerMultiplier && numberOfComrades > 1 * farmerMultiplier)
                BuyFarmerButton.GetComponentInChildren<TextMeshProUGUI>().text = "Buy x" + farmerMultiplier + " Farmers";
        }

        if (countType == "Commune")
        {
            print("update commune button");
        }
    }
}
