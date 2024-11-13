using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TreeCondition : MonoBehaviour
{
    public float curValue;
    public float maxValue;
    public float passiveValue;
    public Image uiBar;
    public TextMeshProUGUI curValueText;

    private void Update()
    {
        uiBar.fillAmount = GetPrecentage();
    }

    private float GetPrecentage()
    {
        return curValue / maxValue;
    }

    private string GetCurValueText()
    {
        return $"{curValue.ToString("N1")} / {maxValue}";
    }

    public void Add(float value)
    {
        curValue = Mathf.Min(curValue + value, maxValue);
    }

    public void Substract(float value)
    {
        curValue = Mathf.Max(curValue - value, 0);
    }
}
