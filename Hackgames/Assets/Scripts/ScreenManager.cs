using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenManager : MonoBehaviour
{
    private const int SCORE_INCREMENT = 15;
    static private ScreenManager instance;
    static public ScreenManager Instance
    {
        get
        {
            return instance;
        }
    }

    public Action RestartEvent;

    [SerializeField] private Text gameOverT;
    [SerializeField] private Text scoreT;
    [SerializeField] private Text topScore;
    [SerializeField] private GameObject restartButton;
    [SerializeField] private Text debug;

    private int score;

    void Awake()
    {
        instance = this;
    }

    public void RestartGame()
    {
        score = 0;
        scoreT.text = "";

        restartButton.SetActive(false);
        gameOverT.enabled = false;
        topScore.enabled = false;
        if (RestartEvent != null)
            RestartEvent();
    }

    public void GameOverShow()
    {
        gameOverT.enabled = true;
        restartButton.SetActive(true);
        scoreT.text = "";

        List<int> highScore = new List<int>();
        highScore.Add(score);
        highScore.Add(PlayerPrefs.GetInt("TopScore1",0));
        highScore.Add(PlayerPrefs.GetInt("TopScore2",0));
        highScore.Add(PlayerPrefs.GetInt("TopScore3",0));
        
        highScore.Sort();
        highScore.Reverse();
        
        PlayerPrefs.SetInt("TopScore1", highScore[0]);
        PlayerPrefs.SetInt("TopScore2", highScore[1]);
        PlayerPrefs.SetInt("TopScore3", highScore[2]);

        topScore.text = "TOP SCORE \n" +
            "1."+ highScore[0] + "\n" +
            "2." + highScore[1] + "\n" +
            "3." + highScore[2];
        topScore.enabled = true;
    }

    public void GameOverHide()
    {
        gameOverT.enabled = false;
    }

    public void Log(string text)
    {
        debug.text = text;
    }
#if UNITY_EDITOR
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameManager.Instance.CircleGenerator.DebugOnCircleComplete();
        }
    }

#endif
    public void OnCircleComplete()
    {
        score += SCORE_INCREMENT;
        scoreT.text = score.ToString();
    }

    private static Quaternion GyroToUnity(Quaternion q)
    {
        return new Quaternion(q.x, q.y, -q.z, -q.w);
    }
}
