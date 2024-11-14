using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum ItemType
{
    Passive,
    Usable
}

public enum EffectStatType
{
    GrowthValue,
    Moisture,
    Nutrition
}

[Serializable]
public class PassiveEffect
{
    public EffectStatType effectStatType;
    public float effectValue;
    public float duration;
}

[Serializable]
public class UsableEffect
{
    public EffectStatType effectStatType;
    public float effectValue;
    public int useCount;
}

[CreateAssetMenu(fileName = "ItemData", menuName = "DataSO/ItemData")]
public class ItemDataSO : ScriptableObject
{
    public int id;
    public string itemName;
    public int price;
    public ItemType itemtype;
    public bool isOwned;

    [Header("Passive")]
    public PassiveEffect[] passiveEffects;

    [Header("Usable")]
    public UsableEffect[] usableEffects;
}
