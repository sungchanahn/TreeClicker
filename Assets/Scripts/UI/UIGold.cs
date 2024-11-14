using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIGold : MonoBehaviour
{
    public TextMeshProUGUI amountText;

    private void Awake()
    {
        UIManager.Instance.uiGold = this;
    }

    public void ChangeAmount()
    {
        amountText.text = $"{GameManager.Instance.Player.data.gold}G";
    }
}
