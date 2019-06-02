using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundLerp : MonoBehaviour
{
    float accum;
    Vector3 initPosition;
    Vector3 finishedPosition;
    // Start is called before the first frame update
    void Start()
    {
        initPosition = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.CurrentState == GameState.GameOver)
        {
            accum = 0.01f;
            finishedPosition = transform.localPosition;
        }

        if (ScreenManager.Instance.Score == 0 && GameManager.Instance.CurrentState == GameState.Game && transform.localPosition != initPosition)
        {
            transform.localPosition = Vector3.Lerp(finishedPosition, initPosition, accum);
            Debug.Log(finishedPosition + "/" + initPosition + " : " + accum);
            accum += 0.01f * Time.deltaTime * 60;
        }
        else if(transform.localPosition.z > -13)
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, new Vector3(transform.localPosition.x, transform.localPosition.y, initPosition.z - 0.01f * ScreenManager.Instance.Score), Time.deltaTime * 0.1f);
        }
    }
}
