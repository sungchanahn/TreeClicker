using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerDataSO data;
    public PlayerInputController Input { get; private set; }
    public PlayerCondition Condition { get; set; }
    public GameObject treePrefab;
    public GameObject[] trees;
    public Tree currentTree;

    private void Awake()
    {
        GameManager.Instance.Player = this;
        Input = GetComponent<PlayerInputController>();
        Condition = GetComponent<PlayerCondition>();
        InitializeTrees();
        SetCurrentTree();
    }

    public void InitializeTrees()
    {
        int treeCount = treePrefab.transform.childCount;
        trees = new GameObject[treeCount];
        for (int i = 0; i < treeCount; i++)
        {
            trees[i] = treePrefab.transform.GetChild(i).gameObject;
        }
    }

    public void SetCurrentTree()
    {
        trees[data.curTreeGrowthPhaseIndex].SetActive(true);
        currentTree = trees[data.curTreeGrowthPhaseIndex].GetComponent<Tree>();
        UpdatePlayerData();
    }

    public void UpdatePlayerData()
    {
        data.curTreeName = currentTree.data.treeName;
        data.curTreeGrowthPhaseIndex = currentTree.data.growthPhaseIndex;
    }
}