using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public Animator potatoTimer;

    public void UI_Button_DigPotatoes()
    {
        potatoTimer.SetTrigger("MoveSlider");
    }

    public void UI_Button_BuyFarmer()
    {
        LevelSessionData.Singleton.numberOfPotatoes -= 10;
        LevelSessionData.Singleton.numberOfComrades -= 1;
        LevelSessionData.Singleton.numberOfFarmers += 1;
    }
}
