using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryDataUI : MonoBehaviour
{
    public RectTransform InventoryRect;
    public SpinRewardData SpinRewardData;
    public Image image;
    public TMP_Text Text;
    
    public int Amount;
}

[Serializable]
public class InventoryData
{
    public string RewardName;
    public int Amount;
}