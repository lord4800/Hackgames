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
    private AudioSource[] audios;

    private void Awake()
    {
        instance = this;
        source = GetComponent<AudioSource>();
        audios = GetComponents<AudioSource>();
    }

    public void PlayGameOver()
    {
        source.clip = gameOver;
        source.Play();
        //audios[1].Play();
    }

    public void PlayGateOpen()
    {
        source.clip = gateOpen;
        source.Play();
        //audios[0].Play();
    }
}
