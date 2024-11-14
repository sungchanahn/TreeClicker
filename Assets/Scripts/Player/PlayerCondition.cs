using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCondition : MonoBehaviour
{
    public UICondition uiCondition;
    
    public TreeCondition Growth { get { return uiCondition.growth; } }
    public TreeCondition Moisture { get { return uiCondition.moisture; } }
    public TreeCondition Nutrition { get { return uiCondition.nutrition; } }

    private bool isAchiveGoal = false;


    private void Start()
    {
        InitializeValue();

        GameManager.Instance.Player.Input.OnClickEvent += growTree;        
    }

    private void Update()
    {
        GameManager.Instance.Player.currentTree.data.growth = Growth.curValue;
        GameManager.Instance.Player.currentTree.data.moisture = Moisture.curValue;
        GameManager.Instance.Player.currentTree.data.nutrition = Nutrition.curValue;

        Moisture.Substract(Moisture.passiveValue * Time.deltaTime);
        Nutrition.Substract(Nutrition.passiveValue * Time.deltaTime);

        if (Growth.curValue >= Growth.maxValue && !isAchiveGoal)
        {
            isAchiveGoal = true;
            ChangeTree();
        }
    }

    private void InitializeValue()
    {
        Growth.maxValue = GameManager.Instance.Player.currentTree.data.growthGoal;
        Moisture.maxValue = GameManager.Instance.Player.currentTree.data.maxMoisture;
        Nutrition.maxValue = GameManager.Instance.Player.currentTree.data.maxNutrition;

        Growth.curValue = GameManager.Instance.Player.currentTree.data.growth;
        Moisture.curValue = GameManager.Instance.Player.currentTree.data.maxMoisture * 0.5f;
        Nutrition.curValue = GameManager.Instance.Player.currentTree.data.maxNutrition * 0.5f;

        Moisture.passiveValue = GameManager.Instance.Player.currentTree.data.passiveValue;
        Nutrition.passiveValue = GameManager.Instance.Player.currentTree.data.passiveValue;
    }

    public void growTree()
    {
        Growth.Add(GameManager.Instance.Player.data.growthValuePerClick);
        Debug.Log(Growth.curValue);
    }

    private void ChangeTree()
    {
        GameManager.Instance.Player.data.curTreeGrowthPhaseIndex += 1;
        GameManager.Instance.Player.SetCurrentTree();
        InitializeValue();
        isAchiveGoal = false;
    }
}
