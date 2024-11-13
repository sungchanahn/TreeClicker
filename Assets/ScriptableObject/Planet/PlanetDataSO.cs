using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlanetData", menuName = "DataSO/PlanetData")]
public class PlanetDataSO : ScriptableObject
{
    public float id;
    public float planetName;
    public float terraformingIndex;
}
