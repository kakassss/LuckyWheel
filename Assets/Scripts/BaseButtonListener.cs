using UnityEngine;
using UnityEngine.UI;

public abstract class BaseButtonListener : MonoBehaviour
{
    [SerializeField] protected Button _button;

    private void Awake()
    {
        AddListener();
    }

    private void AddListener()
    {
        _button.onClick.AddListener(OnClick);
    }

    protected virtual void ButtonDisabled()
    {
        _button.interactable = false;
    }

    protected virtual void ButtonEnabled()
    {
        _button.interactable = true;
    }
    
    protected abstract void OnClick();
}
