using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleAnimateProvider : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void OnRiseEnd()
    {
        animator.ResetTrigger("End");
        //TODO: Circle stuff
    }

    public void OnCircleComplit()
    {
        animator.SetTrigger("End");
    }

    public void OnCircleEnd()
    {
        this.gameObject.SetActive(false);
    }
}
