using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Zenject;

[Serializable]
public class SpinRewardUIData
{
    public Image Image;
    public TMP_Text Text;
}

public class SpinRewardsUI : MonoBehaviour
{
    [SerializeField] private List<SpinRewardUIData> _spinRewardUIData;
    
    private SpinRewardManager _spinRewardManager;

    [Inject]
    private void Construct(SpinRewardManager spinRewardManager)
    {
        _spinRewardManager = spinRewardManager;
    }

    private void OnEnable()
    {
        SetUI();
    }

    private void SetUI()
    {
        for (int i = 0; i < _spinRewardUIData.Count; i++)
        {
            _spinRewardUIData[i].Text.gameObject.SetActive(_spinRewardManager.CurrentSpinRewardData[i].Amount > 0);

            _spinRewardUIData[i].Text.text = _spinRewardManager.CurrentSpinRewardData[i].Amount.ToString();
            _spinRewardUIData[i].Image.sprite = _spinRewardManager.CurrentSpinRewardData[i].Icon;
        }
    }
}
