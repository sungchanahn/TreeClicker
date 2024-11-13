using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICondition : MonoBehaviour
{
    public TreeCondition growth;
    public TreeCondition moisture;
    public TreeCondition nutrition;

    private void Start()
    {
        GameManager.Instance.Player.Condition.uiCondition = this;
    }
}
