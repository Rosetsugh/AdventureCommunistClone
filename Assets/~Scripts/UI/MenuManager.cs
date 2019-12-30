using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Singleton { get; private set; }

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

    public Animator potatoTimer;

    public void UI_Button_DigPotatoes()
    {
        potatoTimer.SetTrigger("MoveSlider");
    }

    public delegate void UpdateSliderText();
    public static event UpdateSliderText updateSliderText;

    public void UI_Button_BuyFarmer()
    {
        LevelSessionData.Singleton.numberOfPotatoes -= 10;
        LevelSessionData.Singleton.numberOfComrades -= 1;
        LevelSessionData.Singleton.numberOfFarmers += 1;

        if (updateSliderText != null)
            updateSliderText();
    }
}
