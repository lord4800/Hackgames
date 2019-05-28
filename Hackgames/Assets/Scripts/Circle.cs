using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle : MonoBehaviour
{
    const float TRANSFORM_ANGLE = 100f;
    const float EPSILON = 3f;

    private Vector3 targerVec;
    public TimerManager TimeManager;

    private void Awake()
    {

        if (TimeManager == null)
        TimeManager = GetComponentInChildren<TimerManager>();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 newRot = new Vector3(0, 0, InputManager.Instance.rotateDevice.x * TRANSFORM_ANGLE);
        if (Mathf.Abs( newRot.z - targerVec.z) > EPSILON)
            targerVec = newRot;
    }
    void Update()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation,Quaternion.Euler(targerVec),0.3f);
    }
}
