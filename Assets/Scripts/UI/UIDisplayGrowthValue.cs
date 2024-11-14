using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIDisplayGrowthValue : MonoBehaviour
{
    public GameObject displayUI;

    [SerializeField] private float displayTime;
    WaitForSeconds duration;

    private void Awake()
    {
        UIManager.Instance.uiDisplay = this;
    }

    private void Start()
    {
        GameManager.Instance.Player.Input.OnClickEvent += OnClickDisplay;

        duration = new WaitForSeconds(displayTime);
    }

    // ���߿� �� ��ũ��Ʈ�� �ƴ϶� �ش� UI�� Prefab���� ����� ObjectPool�� ���
    // Ŭ���� ������ ������Ʈ Ǯ���� �ش� UI ���� ����
    public void OnClickDisplay()
    {
        if (!displayUI.activeInHierarchy)
            StartCoroutine(DisplayUI());
    }

    IEnumerator DisplayUI()
    {
        displayUI.SetActive(true);
        yield return duration;
        displayUI.SetActive(false);
    }
}
