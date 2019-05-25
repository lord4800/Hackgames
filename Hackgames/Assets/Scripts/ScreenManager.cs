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
    [SerializeField] private Text debug;

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

    public void Log(string text)
    {
        debug.text = text;
    }
    private static Quaternion GyroToUnity(Quaternion q)
    {
        return new Quaternion(q.x, q.y, -q.z, -q.w);
    }
}
