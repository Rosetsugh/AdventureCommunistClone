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
    public int farmerMultiplyer;

    private void Start()
    {
        farmerMultiplyer = 1;
    }

    public void UI_Button_DigPotatoes()
    {
        potatoTimer.SetTrigger("MoveSlider");
    }

    public delegate void UpdateSliderText();
    public static event UpdateSliderText updateSliderText;

    public void UI_Button_BuyFarmer()
    {
        LevelSessionData.Singleton.numberOfPotatoes -= 10 * farmerMultiplyer;
        LevelSessionData.Singleton.numberOfComrades -= 1 * farmerMultiplyer;
        LevelSessionData.Singleton.numberOfFarmers += 1 * farmerMultiplyer;

        if (updateSliderText != null)
            updateSliderText();
    }
}
