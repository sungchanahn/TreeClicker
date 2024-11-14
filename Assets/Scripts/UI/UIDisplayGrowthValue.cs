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

    // 나중에 이 스크립트가 아니라 해당 UI를 Prefab으로 만들고 ObjectPool을 사용
    // 클릭할 때마다 오브젝트 풀에서 해당 UI 꺼내 쓰게
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
