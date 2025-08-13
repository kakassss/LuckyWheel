using System;
using UnityEngine;

[CreateAssetMenu(fileName = "InoutHelper", menuName = "ScriptableObjects/InoutHelper")]
public class InoutSO : ScriptableObject
{
    [Serializable]
    public class InOutDictionary : SerializableDictionary<int, Sprite>{}
    [SerializeField] public InOutDictionary InoutDictionary;
}

public enum InoutType
{
    Coin = 0,
    ArmorPoints,
    KnifePoints,
    PistolPoints,
    RiflePoints,
    SmgPoints,
    SniperPoints,
    Death
}

/*
    Coin
    ArmorPoints
    KnifePoints
    PistolPoints
    RiflePoints
    SMGPoints
    SniperPoints
    Death
*/