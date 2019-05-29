using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShevronActivator : MonoBehaviour
{
    SpriteRenderer Renderer;
    // Start is called before the first frame update
    void Start()
    {
        Renderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("OnTriggerEnter");

        if (collision.gameObject.layer == this.gameObject.layer)
        {
            if (Renderer != null)
                Renderer.enabled = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == this.gameObject.layer)
        {
            if (Renderer != null)
                Renderer.enabled = false;
        }
    }
}
