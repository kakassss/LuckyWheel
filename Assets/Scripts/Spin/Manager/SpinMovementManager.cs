using DG.Tweening;
using UnityEngine;

public class SpinMovementManager
{
    private const int SPIN_ANGLE = 45;
    private const float SPIN_360 = 360;
    private const int SPIN_360AMOUNT = 1;
    
    private Vector3 targetRotation;
    private float duration = 2f;
    
    private readonly SpinEvents _spinEvents;
    private readonly SpinRewardManager _spinRewardManager;
    private readonly SpinRotationProvider _spinRotationProvider;

    public SpinMovementManager(SpinEvents spinEvents, SpinRewardManager spinRewardManager, SpinRotationProvider spinRotationProvider)
    {
        _spinEvents = spinEvents;
        _spinRewardManager = spinRewardManager;
        _spinRotationProvider = spinRotationProvider;
    }

    public void SetTargetRotation()
    {
        var randomAngle = (SPIN_ANGLE * _spinRewardManager.CurrentSpinAngleRewardIndex) + (SPIN_360 * SPIN_360AMOUNT);
        targetRotation = new Vector3(0, 0, randomAngle);
    }
    
    public void StartMovement(Transform transform)
    {
        transform.DORotate(targetRotation, duration, RotateMode.FastBeyond360)
            .SetEase(Ease.InOutQuad)
            .OnComplete((() =>
            {
                _spinRotationProvider.SpinLastRotation = transform.rotation; 
                _spinEvents.FireSpinMovementEnd();
                _spinEvents.FireOnSpinActionsEnd();
            }));
    }
}
