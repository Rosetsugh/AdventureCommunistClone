﻿using TMPro;
using UnityEngine;

public class UpdateCounters : MonoBehaviour
{
    private string _countType;

    private void Awake()
    {
        if (GetComponentInParent<SliderCountType>() != null)
            _countType = GetComponentInParent<SliderCountType>().countType;
    }

    private void OnEnable()
    {        
        if(_countType == null)
            UpdateSliderTextExit.updateNumberOfPotatoes += UpdatePotatoCounterEVH;

        if (_countType == "Farmer")  
            UpdateSliderTextExit.updateNumberOfFarmers += UpdateFarmerCounterEVH;
    }

    private void OnDisable()
    {
        if (_countType == null)
            UpdateSliderTextExit.updateNumberOfPotatoes -= UpdatePotatoCounterEVH;

        if (_countType == "Farmer")
            UpdateSliderTextExit.updateNumberOfFarmers -= UpdateFarmerCounterEVH;
    }

    public delegate void UpdateButtonText(int farmerMultiplyer);
    public static event UpdateButtonText updateButtonText;

    private void UpdatePotatoCounterEVH()
    {
        GetComponent<TextMeshProUGUI>().text = LevelSessionData.Singleton.NumberOfPotatoes.ToString();

        var multiplier = LevelSessionData.Singleton.NumberOfPotatoes / 10;

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
        GetComponent<TextMeshProUGUI>().text = LevelSessionData.Singleton.NumberOfFarmers.ToString();
    }
}