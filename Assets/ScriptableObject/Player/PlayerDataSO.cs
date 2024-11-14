using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "DataSO/PlayerData")]
public class PlayerDataSO : ScriptableObject
{
    public string curTreeName;
    public int curTreeGrowthPhaseIndex;
    public float growthValuePerClick;
    public int gold;
}
