using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TODO: Generate bonus collect items
public class CircleManager : MonoBehaviour
{
    static private CircleManager instance;
    static public CircleManager Instance
    {
        get
        {
            return instance;
        }
    }

    [SerializeField] private float circleTimerAnsver;
    [SerializeField] private float circleTimeBetween;
    [SerializeField] private AnimationCurve difficultCurve;
    [SerializeField] private List<GameObject> circlePrefabs = new List<GameObject>();

    private float difficult;
    private Coroutine ansverCorout;
    private List<GameObject> circlePool = new List<GameObject>();
    private GameObject currentCircle;

    private GameObject Circle
    {
        get
        {
            currentCircle = circlePool[Random.Range(0, circlePrefabs.Count)];
            ScreenManager.Instance.Log(currentCircle.name);
            return currentCircle;
        }
    }

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        InputManager.Instance.CircleCompleteEvent += OnCircleComplete;
        StartCoroutine(CircleGeneration());
        for (int i = 0; i < circlePrefabs.Count; i++)
        {
            GameObject circle = circlePrefabs[i];
            circle.SetActive(false);
            circlePool.Add(Instantiate(circle));
        }
    }

    IEnumerator CircleGeneration()
    {
        yield return new WaitForSeconds(circleTimerAnsver * difficultCurve.Evaluate(difficult));
        CircleActivate(Circle);
    }

    void CircleActivate(GameObject circle)
    {
        Debug.Log("Activate Circle");
        circle.SetActive(true);
    }

    public void OnRaiseEnd()
    {
        Debug.Log("Rise Circle");
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
        Debug.Log("Circle Complete");
        ScreenManager.Instance.OnCircleComplete();
        StopCoroutine(ansverCorout);
        CircleClose();
        StartCoroutine(CircleGeneration());
    }

    private void GameOver()
    {
        Debug.Log("GameOver");
        CircleClose();
        ScreenManager.Instance.GameOverShow();
        GameManager.Instance.CurrentState = GameState.GameOver;
    }

    private void CircleClose()
    {
        ScreenManager.Instance.Log("");
        ansverCorout = null;
        currentCircle.GetComponent<CircleAnimateProvider>().OnCircleComplit();
    }
}
