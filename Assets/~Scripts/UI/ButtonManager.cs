using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour 
{
    private void OnEnable()
    {
        if (tag != "Untagged")
        {
            UpdateSliderTextExit.unlockBuyButton += UnlockButtonEVH;
            UpdateSliderTextExit.lockBuyButton += LockButtonEVH;
            
        }

        if(tag == "BuyFarmers")
            UpdateCounters.updateButtonText += UpdateBuyFarmersButtonTextEVH;

        if (tag == "BuyCommunes")
            UpdateCounters.updateButtonText += UpdateBuyCommunesButtonTextEVH;
    }

    private void OnDisable()
    {
        if (tag != "Untagged")
        {
            UpdateSliderTextExit.unlockBuyButton -= UnlockButtonEVH;
            UpdateSliderTextExit.lockBuyButton -= LockButtonEVH;
            
        }

        if (tag == "BuyFarmers")
            UpdateCounters.updateButtonText -= UpdateBuyFarmersButtonTextEVH;

        if (tag == "BuyCommunes")
            UpdateCounters.updateButtonText -= UpdateBuyCommunesButtonTextEVH;
    }

    private void UnlockButtonEVH(string buttonType)
    {
        if(tag == buttonType)
            GetComponent<Button>().interactable = true;
    }

    private void LockButtonEVH(string buttonType)
    {
        if (tag == buttonType)
            GetComponent<Button>().interactable = false;
    }

    private void UpdateBuyFarmersButtonTextEVH(int farmerMultiplier)
    {
        if(farmerMultiplier == 0)
            GetComponentInChildren<TextMeshProUGUI>().text = "Buy x1 Farmer";

        else
            GetComponentInChildren<TextMeshProUGUI>().text = "Buy x" + farmerMultiplier + " Farmers";
    }

    private void UpdateBuyCommunesButtonTextEVH(int communeMultiplier)
    {
        if (communeMultiplier == 0)
            GetComponentInChildren<TextMeshProUGUI>().text = "Buy x1 Commune";

        else
            GetComponentInChildren<TextMeshProUGUI>().text = "Buy x" + communeMultiplier + " Communes";
    }
}