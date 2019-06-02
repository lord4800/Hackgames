using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleManager : MonoBehaviour
{ 
    [SerializeField] private float circleTimerAnsver;
    [SerializeField] private float circleTimeBetween;
    [SerializeField] private AnimationCurve difficultCurve;
    [SerializeField] private List<GameObject> circlePrefabs = new List<GameObject>();

    private int previousAngle;
    private float difficult;
    private Coroutine ansverCorout;
    private List<GameObject> circlePool = new List<GameObject>();
    private GameObject currentCircle;

    public Action CircleCompleteEvent;

    private GameObject Circle
    {
        get
        {
            List<GameObject> pool = new List<GameObject>(circlePool);
            pool.Remove(currentCircle);
            currentCircle = pool[UnityEngine.Random.Range(0, pool.Count)];
            ScreenManager.Instance.Log(currentCircle.name);

            // Random circle active group angle setting
            int angle = GenerateRandomAngle(-70, 70);
            currentCircle.transform.GetChild(0).transform.rotation = Quaternion.Euler(0, 0, angle);
            return currentCircle;
        }
    }

    void Start()
    {
        GameManager.Instance.CircleGenerator = this;

        CircleCompleteEvent += EffectManager.Instance.PlayGateOpen;
        CircleCompleteEvent += ParticleManager.Instance.PlayWarp;
        CircleCompleteEvent += ScreenManager.Instance.OnCircleComplete;

        InputManager.Instance.CircleCompleteEvent += OnCircleComplete;
        ScreenManager.Instance.RestartEvent += Restart;
        StartCoroutine(CircleGeneration());
        for (int i = 0; i < circlePrefabs.Count; i++)
        {
            GameObject circle = circlePrefabs[i];
            circle.SetActive(false);
            circlePool.Add(Instantiate(circle));
        }

        previousAngle = 0;
    }

    public void Restart()
    {
        GameManager.Instance.CurrentState = GameState.Game;
        StartCoroutine(CircleGeneration());
        difficult = 0f;
    }

    IEnumerator CircleGeneration()
    {
        float waitTimer = circleTimeBetween * difficultCurve.Evaluate(difficult);
        yield return new WaitForSeconds(waitTimer);
        CircleActivate(Circle);
    }

    void CircleActivate(GameObject circle)
    {
        currentCircle.GetComponent<CircleAnimateProvider>().TimeManager.UpdateTimer(1);
        circle.SetActive(true);
    }

    public void OnRaiseEnd()
    {
        ansverCorout = StartCoroutine(CircleReaction());
    }

    private void Update()
    {
        difficult += Time.deltaTime;
    }

    IEnumerator CircleReaction()
    {
        float timer = circleTimerAnsver * difficultCurve.Evaluate(difficult);
        for (float t = 0; t < timer; t += Time.deltaTime)
        {
            currentCircle.GetComponentInChildren<TimerManager>().UpdateTimer(1-t/timer);
            yield return null;
        }
        GameOver();
    }

    public void OnCircleComplete()
    {
        if (GameManager.Instance.CurrentState != GameState.Game || ansverCorout == null)
            return;
        if (!currentCircle.GetComponent<CircleAnimateProvider>().CircleComplit)
            return;
        if (CircleCompleteEvent != null)
            CircleCompleteEvent();

        StopAllCoroutines();
        CircleClose();
        StartCoroutine(CircleGeneration());
    }

    public void DebugOnCircleComplete()
    {
        if (CircleCompleteEvent != null)
            CircleCompleteEvent();

        StopAllCoroutines();
        CircleClose();
        StartCoroutine(CircleGeneration());
    }

    private void GameOver()
    {
        CircleClose();
        
        GameManager.Instance.CurrentState = GameState.GameOver;
    }

    private void CircleClose()
    {
        ScreenManager.Instance.Log("");
        ansverCorout = null;
        currentCircle.GetComponent<CircleAnimateProvider>().OnCircleComplit();
    }

    private int GenerateRandomAngle(int min, int max)
    {
        int angle;
        do
        {
            angle = UnityEngine.Random.Range(min, max + 1);
        }
        while (Math.Abs(previousAngle - angle) < 30);
        previousAngle = angle;
        //Debug.Log(previousAngle);
        return angle;

    }
}
