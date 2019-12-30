using UnityEngine;

public class Menu : MonoBehaviour
{
    private Animator _animator;
    public Menu currentMenu;

    public bool openMenu
    {
        get { return _animator.GetBool("openMenu"); }
        set { _animator.SetBool("openMenu", value); }
    }

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void UI_Button_OpenMenu(Menu nextMenu)
    {
        if (currentMenu != null)
            currentMenu.openMenu = false;

        currentMenu = nextMenu;
        currentMenu.openMenu = true;
    }
}