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
