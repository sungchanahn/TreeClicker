using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    private Player player;

    public Player Player 
    { 
        get { return player; }
        set { player = value; }
    }

    [SerializeField] private int goldGainProbability = 20;
    [SerializeField] private int minGold = 1;
    [SerializeField] private int maxGold = 10;

    protected override void Awake()
    {
        base.Awake();
    }

    private void Start()
    {
        Player.Input.OnClickEvent += GainRandomGold;
    }

    private void GainRandomGold()
    {
        if (IsAppearGold())
        {
            Player.data.gold += GetRandomGold();
            Debug.Log(Player.data.gold + "G");

            UIManager.Instance.uiGold.ChangeAmount();
        }
    }

    private int GetRandomGold()
    {
        return Random.Range(minGold, maxGold + 1);
    }

    private bool IsAppearGold()
    {
        int randomNum = Random.Range(0, 100);
        return goldGainProbability > randomNum;
    }
}
