using UnityEngine;

public class Menu : MonoBehaviour
{
    private Animator _animator;

    public bool openMenu
    {
        get { return _animator.GetBool("openMenu"); }
        set { _animator.SetBool("openMenu", value); }
    }

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }
}
