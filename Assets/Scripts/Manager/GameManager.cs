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

    [SerializeField] private int goldGainProbability;
    [SerializeField] private int minGold;
    [SerializeField] private int maxGold;

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
        }
    }

    private int GetRandomGold()
    {
        return Random.Range(minGold, maxGold);
    }

    private bool IsAppearGold()
    {
        int randomNum = Random.Range(0, 100);
        return goldGainProbability > randomNum;
    }
}
