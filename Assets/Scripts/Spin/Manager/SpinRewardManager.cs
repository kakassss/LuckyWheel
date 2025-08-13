using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpinRewardManager
{
    public int CurrentSpinAngleRewardIndex => _currentSpinAngleRewardIndex;
    public List<SpinRewardData> CurrentSpinRewardDataList => _currentSpinRewardDataList;
    public SpinRewardData CurrentSpinRewardData => _currentSpinRewardData;
    
    private List<SpinRewardData> _bronzeSpinRewardDataList = new List<SpinRewardData>();
    private List<SpinRewardData> _silverSpinRewardDataList = new List<SpinRewardData>();
    private List<SpinRewardData> _goldenSpinRewardDataList = new List<SpinRewardData>();

    private List<SpinRewardData> _currentSpinRewardDataList = new List<SpinRewardData>();
    
    private readonly SpinRewardsDataSO _spinRewardsDataSO;
    private readonly SpinIndexManager _spinIndexManager;
    private int _currentSpinAngleRewardIndex;
    private SpinRewardData _currentSpinRewardData;
    
    public SpinRewardManager(SpinRewardsDataSO spinRewardsDataSO, SpinIndexManager spinIndexManager)
    {
        _spinRewardsDataSO = spinRewardsDataSO;
        _spinIndexManager = spinIndexManager;
        
        SetSpinRewardData();

        _currentSpinRewardDataList = _spinRewardsDataSO._silverSpinRewards;
    }

    private void SetSpinRewardData()
    {
        _bronzeSpinRewardDataList = _spinRewardsDataSO._bronzeSpinRewards;
        _silverSpinRewardDataList = _spinRewardsDataSO._silverSpinRewards;
        _goldenSpinRewardDataList = _spinRewardsDataSO._goldenSpinRewards;
    }

    public void SetSpinRewardIndex()
    {
        if (_spinIndexManager.CurrentSpinIndex % 30 == 0)
        {
            _currentSpinAngleRewardIndex = Random.Range(0, _goldenSpinRewardDataList.Count);
            _currentSpinRewardDataList = _goldenSpinRewardDataList;
            _currentSpinRewardData = _currentSpinRewardDataList[_currentSpinAngleRewardIndex];
            return;
        }

        if (_spinIndexManager.CurrentSpinIndex % 5 == 0)
        {
            _currentSpinAngleRewardIndex = Random.Range(0, _silverSpinRewardDataList.Count);
            _currentSpinRewardDataList = _silverSpinRewardDataList;
            _currentSpinRewardData = _currentSpinRewardDataList[_currentSpinAngleRewardIndex];
            return;
        }

        Debug.Log(_currentSpinRewardDataList[_currentSpinAngleRewardIndex].RewardName);
        
        _currentSpinAngleRewardIndex = Random.Range(0, _bronzeSpinRewardDataList.Count);
        _currentSpinRewardDataList = _bronzeSpinRewardDataList;
        _currentSpinRewardData = _currentSpinRewardDataList[_currentSpinAngleRewardIndex];
    }
}