using UnityEngine;

public class SpinActionManager
{
    private readonly SpinMovementManager _spinMovementManager;
    private readonly SpinRewardManager _spinRewardManager;
    private readonly InventoryManager _inventoryManager;
    
    public SpinActionManager(SpinRewardManager spinRewardManager, SpinMovementManager spinMovementManager,
        InventoryManager inventoryManager)
    {
        _spinRewardManager = spinRewardManager;
        _spinMovementManager = spinMovementManager;
        _inventoryManager = inventoryManager;
    }
    
    public void StartActions(Transform transform)
    {
        _spinRewardManager.SetSpinRewardIndex();
        _spinMovementManager.SetTargetRotation();
        _spinMovementManager.StartMovement(transform);
        
        _inventoryManager.AddNewRewardData(_spinRewardManager.CurrentSpinRewardData);
    }
}