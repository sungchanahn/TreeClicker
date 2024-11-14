using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerDataSO data;
    public PlayerInputController Input { get; private set; }
    public PlayerCondition Condition { get; set; }
    public GameObject[] trees;
    public Tree currentTree;
    public Transform treeSpawnPosition;

    private void Awake()
    {
        GameManager.Instance.Player = this;
        Input = GetComponent<PlayerInputController>();
        Condition = GetComponent<PlayerCondition>();
        SetCurrentTree();
    }

    public GameObject SpawnTree()
    {
        return Instantiate(trees[data.curTreeGrowthPhaseIndex], treeSpawnPosition).gameObject;
    }

    public void SetCurrentTree()
    {
        if (currentTree != null)
        {
            Destroy(currentTree.gameObject);
        }
        currentTree = SpawnTree().GetComponent<Tree>();
        UpdatePlayerData();
    }

    public void UpdatePlayerData()
    {
        data.curTreeName = currentTree.data.treeName;
        data.curTreeGrowthPhaseIndex = currentTree.data.growthPhaseIndex;
    }
}