using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITutorialController : MonoBehaviour
{

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            ActivateCircleManager();
            gameObject.SetActive(false);
        }
    }

    public void ActivateCircleManager()
    {
        GameObject.Find("Managers").GetComponent<CircleManager>().enabled = true;
    }

    
}
