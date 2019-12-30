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
        }
    }

    private void OnDisable()
    {
        if (tag == "BuyFarmers")
        {
            UpdateSliderTextExit.unlockBuyFarmersButton -= UnlockBuyFarmersButtonEVH;
            UpdateSliderTextExit.lockBuyFarmersButton -= LockBuyFarmersButtonEVH;
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
}