using UnityEngine;
using Zenject;

public class SpinButtonListener : BaseButtonListener
{
    [SerializeField] private Transform _spinTransform;
    
    private SpinActionManager _spinActionManager;
    private SpinEvents _spinEvents;
    private SpinRotationProvider _spinRotationProvider;
    
    [Inject]
    private void Construct(SpinActionManager spinActionManager, SpinEvents spinEvents, SpinRotationProvider spinRotationProvider)
    {
        _spinActionManager = spinActionManager;
        _spinEvents = spinEvents;
        _spinRotationProvider = spinRotationProvider;
    }

    private void OnEnable()
    {
        _spinTransform.rotation = _spinRotationProvider.SpinLastRotation;
        _spinEvents.AddOnSpinActionsEnd(ButtonEnabled);
    }

    private void OnDisable()
    {
        _spinEvents.RemoveOnSpinActionsEnd(ButtonEnabled);
    }

    protected override void OnClick()
    {
        ButtonDisabled();
        _spinActionManager.StartActions(_spinTransform);
    }
}
