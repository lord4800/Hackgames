using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectManager : MonoBehaviour
{
    static private EffectManager instance;
    static public EffectManager Instance
    {
        get
        {
            return instance;
        }
    }

    [SerializeField] private AudioClip gameOver;
    [SerializeField] private AudioClip gateOpen;

    private AudioSource source;

    private void Awake()
    {
        instance = this;
        source = GetComponent<AudioSource>();
    }

    public void PlayGameOver()
    {
        source.clip = gameOver;
        //source.Play();
    }

    public void PlayGateOpen()
    {
        source.clip = gameOver;
        //source.Play();
    }
}
