using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverConnection : Singleton<GameOverConnection>
{ 
    [SerializeField] protected GameObject gameOverScreen;

    protected override void Awake()
    {
        base.Awake();
    }

    void Start()
    {
        PlayerHealth.Instance.deathScreen = gameOverScreen;
    }
}
