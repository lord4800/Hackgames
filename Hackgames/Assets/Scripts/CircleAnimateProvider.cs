﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleAnimateProvider : MonoBehaviour
{
    private Animator animator;
    [SerializeField] private List<SpriteRenderer> activShevrons = new List<SpriteRenderer>();

    private TimerManager timeManager;
    public TimerManager TimeManager    {
        get
        {
            if (timeManager == null)
                timeManager = GetComponentInChildren<TimerManager>();
            return timeManager;
        }
    }

    private void Awake()
    {
        animator = GetComponent<Animator>();
        timeManager = GetComponentInChildren<TimerManager>();
    }

    public void OnRiseEnd()
    {
        animator.ResetTrigger("End");
        //TODO: Circle stuff
        GameManager.Instance.CircleGenerator.OnRaiseEnd();
    }

    public void OnCircleComplit()
    {
        animator.Play("PathCircleEnd");
    }

    public void OnCircleEnd()
    {
        this.gameObject.SetActive(false);
    }

    public bool CircleComplit
    {
        get
        {
            foreach (var item in activShevrons)
            {
                if(item.enabled == false)
                    return false;
            }
            return true;
        }
    }
}
