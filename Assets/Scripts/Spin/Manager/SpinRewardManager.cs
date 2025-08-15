using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpinRewardManager
{
    public int CurrentSpinAngleRewardIndex => _currentSpinAngleRewardIndex;
    public List<SpinRewardData> CurrentSpinRewardDataList => _currentSpinRewardDataList;
    public SpinRewardData CurrentSpinRewardData => _currentSpinRewardData;
    
    private List<SpinRewardData> _currentSpinRewardDataList = new List<SpinRewardData>();
    
    private readonly SpinRewardsDataSO _spinRewardsDataSO;
    private readonly SpinIndexManager _spinIndexManager;
    private int _currentSpinAngleRewardIndex;
    private SpinRewardData _currentSpinRewardData;
    
    public SpinRewardManager(SpinRewardsDataSO spinRewardsDataSO, SpinIndexManager spinIndexManager)
    {
        _spinRewardsDataSO = spinRewardsDataSO;
        _spinIndexManager = spinIndexManager;
        
        _currentSpinRewardDataList = _spinRewardsDataSO._silverSpinRewards;
    }
    
    public void SetSpinRewardIndex()
    {
        if (_spinIndexManager.CurrentSpinIndex % 30 == 0)
        {
            _currentSpinAngleRewardIndex = Random.Range(0, _spinRewardsDataSO._goldenSpinRewards.Count);
            _currentSpinRewardDataList = _spinRewardsDataSO._goldenSpinRewards;
            _currentSpinRewardData = _currentSpinRewardDataList[_currentSpinAngleRewardIndex];
            return;
        }

        if (_spinIndexManager.CurrentSpinIndex % 5 == 0)
        {
            _currentSpinAngleRewardIndex = Random.Range(0, _spinRewardsDataSO._silverSpinRewards.Count);
            _currentSpinRewardDataList = _spinRewardsDataSO._silverSpinRewards;
            _currentSpinRewardData = _currentSpinRewardDataList[_currentSpinAngleRewardIndex];
            return;
        }
        
        _currentSpinAngleRewardIndex = Random.Range(0, _spinRewardsDataSO._bronzeSpinRewards.Count);
        _currentSpinRewardDataList = _spinRewardsDataSO._bronzeSpinRewards;
        _currentSpinRewardData = _currentSpinRewardDataList[_currentSpinAngleRewardIndex];
    }
}