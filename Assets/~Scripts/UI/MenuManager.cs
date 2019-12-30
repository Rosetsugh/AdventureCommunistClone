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
    public int farmerMultiplier;
    public Menu currentMenu;

    private void Start()
    {
        farmerMultiplier = 1;
    }

    public void UI_Button_DigPotatoes()
    {
        potatoTimer.SetTrigger("MoveSlider");
    }

    public delegate void UpdateSliderText();
    public static event UpdateSliderText updateSliderText;

    public void UI_Button_BuyFarmer()
    {
        LevelSessionData.Singleton.numberOfPotatoes -= 10 * farmerMultiplier;
        LevelSessionData.Singleton.numberOfComrades -= 1 * farmerMultiplier;
        LevelSessionData.Singleton.numberOfFarmers += 1 * farmerMultiplier;

        if (updateSliderText != null)
            updateSliderText();
    }

    public void UI_Button_OpenMenu(Menu nextMenu)
    {
        if (currentMenu != null)
            currentMenu.openMenu = false;

        currentMenu = nextMenu;
        currentMenu.openMenu = true;
    }
}
