using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleManager : MonoBehaviour
{
    static private ParticleManager instance;
    static public ParticleManager Instance
    {
        get
        {
            return instance;
        }
    }

    private Animator animator;
    public Animator cameraAnim;

    private void Awake()
    {
        instance = this;
        animator = GetComponent<Animator>();
    }

    public void PlayWarp()
    {
        animator.Play("WarpUpAnimation");
        cameraAnim.Play("WarpAnimationCamera");
    }
}
