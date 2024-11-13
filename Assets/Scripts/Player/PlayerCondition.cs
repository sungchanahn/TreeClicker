using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCondition : MonoBehaviour
{
    public UICondition uiCondition;
    
    public TreeCondition Growth { get { return uiCondition.growth; } }
    public TreeCondition Moisture { get { return uiCondition.moisture; } }
    public TreeCondition Nutrition { get { return uiCondition.nutrition; } }


    private void Start()
    {
        Growth.maxValue = GameManager.Instance.Player.currentTree.data.growthGoal;
        Moisture.maxValue = GameManager.Instance.Player.currentTree.data.maxMoisture;
        Nutrition.maxValue = GameManager.Instance.Player.currentTree.data.maxNutrition;

        Growth.curValue = 0f;
        Moisture.curValue = GameManager.Instance.Player.currentTree.data.maxMoisture * 0.5f;
        Nutrition.curValue = GameManager.Instance.Player.currentTree.data.maxNutrition * 0.5f;

        Moisture.passiveValue = GameManager.Instance.Player.currentTree.data.passiveValue;
        Nutrition.passiveValue = GameManager.Instance.Player.currentTree.data.passiveValue;

        GameManager.Instance.Player.Input.OnClickEvent += growTree;
        StartCoroutine(PassiveGrowth());
    }

    private void Update()
    {
        GameManager.Instance.Player.currentTree.data.growth = Growth.curValue;
        GameManager.Instance.Player.currentTree.data.moisture = Moisture.curValue;
        GameManager.Instance.Player.currentTree.data.nutrition = Nutrition.curValue;

        Moisture.Substract(Moisture.passiveValue * Time.deltaTime);
        Nutrition.Substract(Nutrition.passiveValue * Time.deltaTime);
    }

    public void growTree()
    {
        Growth.Add(GameManager.Instance.Player.data.growthValuePerClick);
        Debug.Log(Growth.curValue);
    }

    IEnumerator PassiveGrowth()
    {
        yield return null;
    }
}
