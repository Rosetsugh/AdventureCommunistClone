using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour 
{
    private void OnEnable()
    {
        UpdateSliderTextExit.unlockBuyFarmersButton += UnlockBuyFarmersButtonEVH;
    }

    private void OnDisable()
    {
        UpdateSliderTextExit.unlockBuyFarmersButton -= UnlockBuyFarmersButtonEVH;
    }

    private void UnlockBuyFarmersButtonEVH()
    {
        GetComponent<Button>().interactable = true;
    }
}