﻿using UnityEngine;
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
    public Animator communeTimer;
    public Menu currentMenu;
    public Transform panelParent;
    public GameObject unlockPanel;
    public GameObject communePanel;

    public void UI_Button_DigPotatoes()
    {
        potatoTimer.SetTrigger("MoveSlider");
    }

    public void UI_Button_CreateCommune()
    {
        communeTimer.SetTrigger("MoveSlider");
    }

    public delegate void UpdateSliderText();
    public static event UpdateSliderText updateSliderText;

    private bool _runOnce;

    public void UI_Button_BuyFarmer(Button button)
    {
        if (LevelSessionData.Singleton.NumberOfPotatoes >= 10 && !_runOnce)
        {
            unlockPanel.SetActive(true);
            _runOnce = true;
        }

        // TODO: Change to numberOfFarmers
        if (LevelSessionData.Singleton.NumberOfPotatoes >= 25)
        {
            unlockPanel.SetActive(false);
            communePanel.SetActive(true);
        }

        LevelSessionData.Singleton.NumberOfPotatoes -= 10 * LevelSessionData.Singleton.farmerMultiplier;
        LevelSessionData.Singleton.numberOfComrades -= 1 * LevelSessionData.Singleton.farmerMultiplier;
        LevelSessionData.Singleton.NumberOfFarmers += 1 * LevelSessionData.Singleton.farmerMultiplier;

        if (updateSliderText != null)
            updateSliderText();

        if (LevelSessionData.Singleton.NumberOfPotatoes < 10 * LevelSessionData.Singleton.farmerMultiplier
            || LevelSessionData.Singleton.numberOfComrades < 1 * LevelSessionData.Singleton.farmerMultiplier)
        {
            button.interactable = false;
        }
    }

    public void UI_Button_BuyCommune(Button button)
    {
        LevelSessionData.Singleton.NumberOfPotatoes -= 100 * LevelSessionData.Singleton.communeMultiplier;
        LevelSessionData.Singleton.numberOfComrades -= 1 * LevelSessionData.Singleton.communeMultiplier;
        LevelSessionData.Singleton.NumberOfFarmers -= 10 * LevelSessionData.Singleton.communeMultiplier;
        LevelSessionData.Singleton.numberOfCommnues += 1 * LevelSessionData.Singleton.communeMultiplier;

        if (updateSliderText != null)
            updateSliderText();

        if (LevelSessionData.Singleton.NumberOfPotatoes < 100 * LevelSessionData.Singleton.communeMultiplier
            || LevelSessionData.Singleton.numberOfComrades < 1 * LevelSessionData.Singleton.communeMultiplier
            || LevelSessionData.Singleton.NumberOfFarmers < 10 * LevelSessionData.Singleton.communeMultiplier)
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
