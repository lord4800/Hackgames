using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShip : MonoBehaviour
{
    const float TRANSFORM_ANGLE = 100f;
    const float EPSILON = 3f;
    private const float SPEED = 3f;

    private Vector3 targerVec;

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 newRot = new Vector3(0, 0, InputManager.Instance.rotateDevice.x * TRANSFORM_ANGLE);
        if (Mathf.Abs(newRot.z - targerVec.z) > EPSILON)
            targerVec = newRot;
    }
    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(targerVec), SPEED * Time.deltaTime);
    }
}