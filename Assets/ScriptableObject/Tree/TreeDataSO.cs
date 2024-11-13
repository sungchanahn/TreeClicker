using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TreeData", menuName = "DataSO/Tree")]
public class TreeDataSO : ScriptableObject
{
    [Header("BaseData")]
    public string treeName;
    public string growthPhase;
    public int growthPhaseIndex;
    public float growthGoal;
    public float maxMoisture;
    public float maxNutrition;
    public float passiveValue;

    [Header("SaveData")]
    public float growth;
    public float moisture;
    public float nutrition;
}
