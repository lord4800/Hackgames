using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerManager : MonoBehaviour
{
    private List<SpriteRenderer> timerPoints = new List<SpriteRenderer>();

    private void Awake()
    {
        if (timerPoints == null || timerPoints.Count <= 0)
        {
            foreach (var item in GetComponentsInChildren<SpriteRenderer>())
            {
                timerPoints.Add(item);
            }
        }
    }

    public void UpdateTimer(float percent)
    {
        int timerCount = (int)(timerPoints.Count * percent);

        for (int i = 0; i < timerPoints.Count; i++)
        {
            SpriteRenderer item = (SpriteRenderer)timerPoints[i];
            if (i < timerCount)
                item.enabled = true;
            else
                item.enabled = false;
        }
    }
    
}
