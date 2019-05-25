using System;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    static private InputManager instance;
    static public InputManager Instance
    {
        get { return instance; }
    }
    public Action CircleCompleteEvent;
    public bool isflat = true;
    public Vector3 rotateDevice
    {
        get
        {
            Vector3 tilt = Input.acceleration;
            if (isflat)
            {
                tilt = Quaternion.Euler(90, 0, 0) * tilt;
            }

            return tilt;
        }
    }

    private static Quaternion GyroToUnity(Quaternion q)
    {
        return new Quaternion(q.x, q.y, -q.z, -q.w);
    }

    private void Awake()
    {
        instance = this;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (CircleCompleteEvent != null)
            {
                CircleCompleteEvent();
            }
        }
    }
}
