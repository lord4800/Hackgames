using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngleAdjuster : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.up = Vector3.zero + transform.position;
    }
}
