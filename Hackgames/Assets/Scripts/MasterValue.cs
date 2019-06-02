using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterValue : MonoBehaviour
{
    [Range(0f, 3f)]
    public float masterVolume = 1.0f;
    // Update is called once per frame
    void Update()
    {
        AudioListener.volume = masterVolume;
    }
}
