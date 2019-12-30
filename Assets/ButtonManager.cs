using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour 
{
    private void OnEnable()
    {
        UpdateSliderTextExit.unlockBuyFarmersButton += UnlockBuyFarmersButtonEVH;
        UpdateSliderTextExit.lockBuyFarmersButton += LockBuyFarmersButtonEVH;
    }

    private void OnDisable()
    {
        UpdateSliderTextExit.unlockBuyFarmersButton -= UnlockBuyFarmersButtonEVH;
        UpdateSliderTextExit.lockBuyFarmersButton -= LockBuyFarmersButtonEVH;
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