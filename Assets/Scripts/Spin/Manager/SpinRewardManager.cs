using System.Collections.Generic;
using Random = UnityEngine.Random;

public class SpinRewardManager
{
    public int CurrentSpinAngleRewardIndex => _currentSpinAngleRewardIndex;
    
    private List<SpinRewardData> _bronzeSpinRewardData = new List<SpinRewardData>();
    private List<SpinRewardData> _silverSpinRewardData = new List<SpinRewardData>();
    private List<SpinRewardData> _goldenSpinRewardData = new List<SpinRewardData>();

    public List<SpinRewardData> CurrentSpinRewardData = new List<SpinRewardData>();
    
    private readonly SpinRewardsDataSO _spinRewardsDataSO;
    private readonly SpinIndexManager _spinIndexManager;
    private int _currentSpinAngleRewardIndex;
    
    public SpinRewardManager(SpinRewardsDataSO spinRewardsDataSO, SpinIndexManager spinIndexManager)
    {
        _spinRewardsDataSO = spinRewardsDataSO;
        _spinIndexManager = spinIndexManager;
        
        SetSpinRewardData();

        CurrentSpinRewardData = _spinRewardsDataSO._silverSpinRewards;
    }

    private void SetSpinRewardData()
    {
        _bronzeSpinRewardData = _spinRewardsDataSO._bronzeSpinRewards;
        _silverSpinRewardData = _spinRewardsDataSO._silverSpinRewards;
        _goldenSpinRewardData = _spinRewardsDataSO._goldenSpinRewards;
    }

    public void SetSpinRewardIndex()
    {
        
        if (_spinIndexManager.CurrentSpinIndex % 30 == 0)
        {
            _currentSpinAngleRewardIndex = Random.Range(0, _goldenSpinRewardData.Count);
            CurrentSpinRewardData = _goldenSpinRewardData;
            return;
        }

        if (_spinIndexManager.CurrentSpinIndex % 5 == 0)
        {
            _currentSpinAngleRewardIndex = Random.Range(0, _silverSpinRewardData.Count);
            CurrentSpinRewardData = _silverSpinRewardData;
            return;
        }

        _currentSpinAngleRewardIndex = Random.Range(0, _bronzeSpinRewardData.Count);
        CurrentSpinRewardData = _bronzeSpinRewardData;
    }
}