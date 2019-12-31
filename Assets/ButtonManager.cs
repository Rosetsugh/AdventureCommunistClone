using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour 
{
    private void OnEnable()
    {
        if (tag == "BuyFarmers")
        {
            UpdateSliderTextExit.unlockBuyButton += UnlockButtonEVH;
            UpdateSliderTextExit.lockBuyButton += LockButton;
            UpdatePotatoCounter.updateButtonText += UpdateButtonTextEVH;
        }

        if (tag == "BuyCommunes")
        {
            
        }
    }

    private void OnDisable()
    {
        if (tag == "BuyFarmers")
        {
            UpdateSliderTextExit.unlockBuyButton -= UnlockButtonEVH;
            UpdateSliderTextExit.lockBuyButton -= LockButton;
            UpdatePotatoCounter.updateButtonText -= UpdateButtonTextEVH;
        }

        if (tag == "BuyCommunes")
        {

        }
    }

    private void UnlockButtonEVH()
    {
        GetComponent<Button>().interactable = true;
    }

    private void LockButton()
    {
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