using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenManager : MonoBehaviour
{
    static private ScreenManager instance;
    static public ScreenManager Instance
    {
        get
        {
            return instance;
        }
    }
    [SerializeField] private Text gameOverT;

    void Awake()
    {
        instance = this;
    }

    public void GameOverShow()
    {
        gameOverT.enabled = true;
    }

    public void GameOverHide()
    {
        gameOverT.enabled = false;
    }
}
