using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class InventoryManager
{
    private List<InventoryData> _inventoryData = new List<InventoryData>();
    private List<InventoryDataUI> _inventoryUI = new List<InventoryDataUI>();
    
    private readonly InventoryDataUI _inventoryDataUI;
    private readonly Transform _inventoryParent;
    private readonly IInstantiator _instantiator;

    public InventoryManager(InventoryDataUI inventoryDataUI, Transform inventoryParent
    , IInstantiator instantiator)
    {
        _inventoryDataUI = inventoryDataUI;
        _inventoryParent = inventoryParent;
        _instantiator = instantiator;
    }
    
    public void AddNewRewardData(SpinRewardData newSpinRewardData)
    {
        if (_inventoryData.Count == 0)
        {
            AddNewData();
            return;
        }
        
        for (int i = 0; i < _inventoryData.Count; i++)
        {
            if (_inventoryData[i].RewardName == newSpinRewardData.RewardName)
            {
                _inventoryData[i].Amount += newSpinRewardData.Amount;
                SetDataUI(newSpinRewardData);
                return;
            }
        }
        
        AddNewData();
        void AddNewData()
        {
            var newInventoryData = new InventoryData();
            newInventoryData.RewardName = newSpinRewardData.RewardName;
            newInventoryData.Amount = newSpinRewardData.Amount;
            _inventoryData.Add(newInventoryData);
            
            var dataUI = _instantiator.InstantiatePrefabForComponent<InventoryDataUI>(_inventoryDataUI);
                
            dataUI.transform.SetParent(_inventoryParent);
            dataUI.transform.localScale = Vector3.one;
            dataUI.SpinRewardData = newSpinRewardData;
            dataUI.image.sprite = newSpinRewardData.Icon;
            dataUI.Text.text = newSpinRewardData.Amount.ToString();
                
            dataUI.Amount += newSpinRewardData.Amount;
                
            _inventoryUI.Add(dataUI);
        }
    }
    
    private void SetDataUI(SpinRewardData newSpinRewardData)
    {
        for (int i = 0; i < _inventoryUI.Count; i++)
        {
            if (_inventoryUI[i].SpinRewardData == newSpinRewardData)
            {
                _inventoryUI[i].Amount += newSpinRewardData.Amount;
                _inventoryUI[i].Text.text = _inventoryUI[i].Amount.ToString();
            }
        }
    }

    public InventoryDataUI GetDataUI(SpinRewardData spinRewardData)
    {
        for (int i = 0; i < _inventoryUI.Count; i++)
        {
            if (_inventoryUI[i].SpinRewardData == spinRewardData)
            {
                return _inventoryUI[i];
            }
        }
        
        return null;
    }
}
