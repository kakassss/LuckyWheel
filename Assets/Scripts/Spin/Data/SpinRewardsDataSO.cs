using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SpinRewardsData", menuName = "ScriptableObjects/Spin Rewards Data")]
public class SpinRewardsDataSO : ScriptableObject
{
    public List<SpinRewardData> _bronzeSpinRewards = new List<SpinRewardData>();
    public List<SpinRewardData> _silverSpinRewards = new List<SpinRewardData>();
    public List<SpinRewardData> _goldenSpinRewards = new List<SpinRewardData>();
}