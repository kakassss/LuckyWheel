using UnityEngine;
using Zenject;

public class SpinButtonListener : BaseButtonListener
{
    [SerializeField] private Transform _spinTransform;
    
    private SpinMovementManager _spinMovementManager;
    private SpinEvents _spinEvents;
    private SpinRotationProvider _spinRotationProvider;
    
    [Inject]
    private void Construct(SpinMovementManager spinMovementManager, SpinEvents spinEvents, SpinRotationProvider spinRotationProvider)
    {
        _spinMovementManager = spinMovementManager;
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
        _spinMovementManager.StartAction(_spinTransform);
    }
}
