using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TODO: Generate bonus collect items
public class CircleManager : MonoBehaviour
{
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
            return currentCircle;
        }
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

    void CircleActivate(GameObject circle)
    {
        Debug.Log(circle);
        circle.SetActive(true);
        ansverCorout = StartCoroutine(CircleReaction());
    }

    IEnumerator CircleGeneration()
    {
        yield return new WaitForSeconds(circleTimerAnsver * difficultCurve.Evaluate(difficult));
        CircleActivate(Circle);
    }

    IEnumerator CircleReaction()
    {
        yield return new WaitForSeconds(circleTimerAnsver * difficultCurve.Evaluate(difficult));
        CircleClose();
        ScreenManager.Instance.GameOverShow();
        GameManager.Instance.CurrentState = GameState.GameOver;
    }

    public void OnCircleComplete()
    {
        if (GameManager.Instance.CurrentState != GameState.Game || ansverCorout == null)
            return;
        Debug.Log("Circle Close");
        StopCoroutine(ansverCorout);
        CircleClose();
        StartCoroutine(CircleGeneration());
    }

    private void CircleClose()
    {
        ansverCorout = null;
        currentCircle.SetActive(false);
    }
}
