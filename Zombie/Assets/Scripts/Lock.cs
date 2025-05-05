using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lock : MonoBehaviour
{
    public Containers unlocked;
    public GameObject hallway2Door;

    public GameObject lockCanvas;
    private bool isVisible = false;

    void Start()
    {
        lockCanvas.SetActive(false);
    }

    void Update()
    {
        if (unlocked.hallway2 == false)
        {
            hallway2Door.GetComponent<BoxCollider2D>().enabled = false;
        }
        else
        {
            hallway2Door.GetComponent<BoxCollider2D>().enabled = true;
        }
    }

    void OnMouseDown()
    {
        if (isVisible == false)
        {
            lockCanvas.SetActive(true);
            isVisible = true;
        }
        else
        {
            lockCanvas.SetActive(false);
            isVisible = false;
        }
    }
}