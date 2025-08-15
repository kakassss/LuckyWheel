using System.Collections.Generic;
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
        
       // _currentSpinRewardDataList = _spinRewardsDataSO._silverSpinRewards;
    }
    
    public void SetSpinRewardData()
    {
        //First Spin is safe 
        if (_spinIndexManager.CurrentSpinIndex == 1)
        {
            _currentSpinRewardDataList = _spinRewardsDataSO._silverSpinRewards;
            _currentSpinAngleRewardIndex = Random.Range(0, _spinRewardsDataSO._silverSpinRewards.Count);
            _currentSpinRewardData = _currentSpinRewardDataList[_currentSpinAngleRewardIndex];
            return;
        }
        
        if (_spinIndexManager.CurrentSpinIndex % 30 == 0)
        {
            _currentSpinRewardDataList = _spinRewardsDataSO._goldenSpinRewards;
            _currentSpinAngleRewardIndex = Random.Range(0, _spinRewardsDataSO._goldenSpinRewards.Count);
            _currentSpinRewardData = _currentSpinRewardDataList[_currentSpinAngleRewardIndex];
            return;
        }

        if (_spinIndexManager.CurrentSpinIndex % 5 == 0)
        {
            _currentSpinRewardDataList = _spinRewardsDataSO._silverSpinRewards;
            _currentSpinAngleRewardIndex = Random.Range(0, _spinRewardsDataSO._silverSpinRewards.Count);
            _currentSpinRewardData = _currentSpinRewardDataList[_currentSpinAngleRewardIndex];
            return;
        }
        
        _currentSpinRewardDataList = _spinRewardsDataSO._bronzeSpinRewards;
        _currentSpinAngleRewardIndex = Random.Range(0, _spinRewardsDataSO._bronzeSpinRewards.Count);
        _currentSpinRewardData = _currentSpinRewardDataList[_currentSpinAngleRewardIndex];
    }
}