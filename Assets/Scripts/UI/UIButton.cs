using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIButton : MonoBehaviour
{
    public void AutoClick()
    {
        GameManager.Instance.Player.Input.StartAutoClick();
    }
}