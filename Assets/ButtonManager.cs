﻿using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour 
{
    private void OnEnable()
    {
        if (tag != "Untagged")
        {
            UpdateSliderTextExit.unlockBuyButton += UnlockButtonEVH;
            UpdateSliderTextExit.lockBuyButton += LockButton;
            UpdatePotatoCounter.updateButtonText += UpdateButtonTextEVH;
        }
    }

    private void OnDisable()
    {
        if (tag != "Untagged")
        {
            UpdateSliderTextExit.unlockBuyButton -= UnlockButtonEVH;
            UpdateSliderTextExit.lockBuyButton -= LockButton;
            UpdatePotatoCounter.updateButtonText -= UpdateButtonTextEVH;
        }
    }

    private void UnlockButtonEVH(string countType)
    {
        if(tag == countType)
            GetComponent<Button>().interactable = true;
    }

    private void LockButton(string countType)
    {
        if (tag == countType)
            GetComponent<Button>().interactable = false;
    }

    private void UpdateButtonTextEVH(int farmerMultiplier)
    {
        if(farmerMultiplier == 0)
            GetComponentInChildren<TextMeshProUGUI>().text = "Buy x1 Farmer";

        else
            GetComponentInChildren<TextMeshProUGUI>().text = "Buy x" + farmerMultiplier + " Farmers";
    }
}