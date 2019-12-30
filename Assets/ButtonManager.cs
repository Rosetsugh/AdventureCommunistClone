using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour 
{
    private void OnEnable()
    {
        if (tag == "BuyFarmers")
        {
            UpdateSliderTextExit.unlockBuyFarmersButton += UnlockBuyFarmersButtonEVH;
            UpdateSliderTextExit.lockBuyFarmersButton += LockBuyFarmersButtonEVH;
            UpdatePotatoCounter.updateButtonText += UpdateButtonTextEVH;
        }
    }

    private void OnDisable()
    {
        if (tag == "BuyFarmers")
        {
            UpdateSliderTextExit.unlockBuyFarmersButton -= UnlockBuyFarmersButtonEVH;
            UpdateSliderTextExit.lockBuyFarmersButton -= LockBuyFarmersButtonEVH;
            UpdatePotatoCounter.updateButtonText -= UpdateButtonTextEVH;
        }
    }

    private void UnlockBuyFarmersButtonEVH()
    {
        GetComponent<Button>().interactable = true;
    }

    private void LockBuyFarmersButtonEVH()
    {
        GetComponent<Button>().interactable = false;
    }

    private void UpdateButtonTextEVH(int farmerMultiplier)
    {
        GetComponentInChildren<TextMeshProUGUI>().text = "Buy x" + farmerMultiplier + " Farmers";
    }
}