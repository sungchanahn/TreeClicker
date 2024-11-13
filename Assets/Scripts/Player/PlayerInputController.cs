using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : MonoBehaviour
{
    public event Action OnClickEvent;

    public void OnClick(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started && isValidClickTree())
        {
            CallClickEvent();
        }
    }

    private void CallClickEvent()
    {
        OnClickEvent?.Invoke();
    }

    public bool isValidClickTree()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

        if (hit.collider != null)
        {
            if (hit.collider.gameObject == gameObject) return true;
        }

        return false;
    }
}
