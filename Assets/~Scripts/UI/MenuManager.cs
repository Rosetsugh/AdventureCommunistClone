using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public Animator potatoTimer;

    public void UI_Button_DigPotatoes()
    {
        potatoTimer.SetTrigger("MoveSlider");
    }
}
