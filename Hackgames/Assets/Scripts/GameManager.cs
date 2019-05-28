using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static private GameManager instance;
    static public GameManager Instance
    {
        get
        {
            return instance;
        }
    }
    private GameState gameState;
    public GameState CurrentState
    {
        get
        {
            return gameState;
        }
        set
        {
            if (value == GameState.GameOver)
            {
                EffectManager.Instance.PlayGameOver();
                ScreenManager.Instance.GameOverShow();
            }
            gameState = value;
        }
    }

    private CircleManager circleGenerator;

    public CircleManager CircleGenerator
    {
        get
        {
            return circleGenerator;
        }

        set
        {
            circleGenerator = value;
        }
    }

    private void Awake()
    {
        instance = this;
    }
}

public enum GameState
{
    Game,
    GameOver
}