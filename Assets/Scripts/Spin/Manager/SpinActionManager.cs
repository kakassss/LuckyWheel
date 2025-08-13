using UnityEngine;

public class SpinActionManager
{
    private readonly SpinMovementManager _spinMovementManager;
    private readonly SpinRewardManager _spinRewardManager;
    
    public SpinActionManager(SpinRewardManager spinRewardManager, SpinMovementManager spinMovementManager)
    {
        _spinRewardManager = spinRewardManager;
        _spinMovementManager = spinMovementManager;
    }
    
    public void StartActions(Transform transform)
    {
        _spinRewardManager.SetSpinRewardIndex();
        _spinMovementManager.SetTargetRotation();
        _spinMovementManager.StartMovement(transform);
    }
}