using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : MonoBehaviour
{
    public event Action OnClickEvent;

    [SerializeField] private float coolDown;
    [SerializeField] private float autoClickDuration;
    [SerializeField] private float autoClickInterval;

    public GameObject autoClickButton;
    public GameObject deactiveAutoClick;

    private WaitForSeconds interval;

    private bool isCoolDown = false;
    private bool isAutoClick = false;

    private void Awake()
    {
        interval = new WaitForSeconds(autoClickInterval);
    }

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

    public void StartAutoClick()
    {
        if (!isCoolDown && !isAutoClick)
        {
            StartCoroutine(AutoClick());
        }
    }

    IEnumerator AutoClick()
    {
        isAutoClick = true;
        float remainAutoClickTime = autoClickDuration;

        while (remainAutoClickTime >= 0f)
        {
            CallClickEvent();
            remainAutoClickTime -= autoClickInterval;
            yield return interval;
        }
        isCoolDown = true;
        isAutoClick = false;
        StartCoroutine(CoolDown());        
    }

    IEnumerator CoolDown()
    {        
        float temp = coolDown;
        autoClickButton.SetActive(false);
        deactiveAutoClick.SetActive(true);

        while (coolDown >= 0)
        {
            coolDown -= Time.deltaTime;
            yield return null;
        }

        coolDown = temp;
        isCoolDown = false;
        autoClickButton.SetActive(true);
        deactiveAutoClick.SetActive(false);
    }
}
