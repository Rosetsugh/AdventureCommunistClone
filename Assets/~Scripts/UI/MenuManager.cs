using UnityEngine;
using UnityEngine.UI;

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
    public Menu currentMenu;
    public Transform panelParent;
    public GameObject unlockPanel;
    public GameObject communePanel;

    public void UI_Button_DigPotatoes()
    {
        potatoTimer.SetTrigger("MoveSlider");
    }

    public delegate void UpdateSliderText();
    public static event UpdateSliderText updateSliderText;

    private bool _runOnce;

    public void UI_Button_BuyFarmer(Button button)
    {
        if (LevelSessionData.Singleton.numberOfPotatoes >= 10 && !_runOnce)
        {
            print("here");
            Instantiate(unlockPanel, panelParent);
            _runOnce = true;
        }

        if (LevelSessionData.Singleton.numberOfPotatoes >= 25)
        {
            unlockPanel.SetActive(false);
            Instantiate(communePanel, panelParent);
        }

        LevelSessionData.Singleton.numberOfPotatoes -= 10 * LevelSessionData.Singleton.farmerMultiplier;
        LevelSessionData.Singleton.numberOfComrades -= 1 * LevelSessionData.Singleton.farmerMultiplier;
        LevelSessionData.Singleton.numberOfFarmers += 1 * LevelSessionData.Singleton.farmerMultiplier;

        if (updateSliderText != null)
            updateSliderText();

        if (LevelSessionData.Singleton.numberOfPotatoes < 10 * LevelSessionData.Singleton.farmerMultiplier
            || LevelSessionData.Singleton.numberOfComrades < 1 * LevelSessionData.Singleton.farmerMultiplier)
        {
            button.interactable = false;
        }
    }

    public void UI_Button_OpenMenu(Menu nextMenu)
    {
        if (currentMenu != null)
            currentMenu.openMenu = false;

        currentMenu = nextMenu;
        currentMenu.openMenu = true;
    }
}
