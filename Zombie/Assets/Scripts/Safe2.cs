using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Safe2 : MonoBehaviour
{
    public Containers unlocked;
    public GameObject safeOpen, lockCanvas;
    private bool isVisible = false;

    void Start()
    {
        safeOpen.SetActive(false);
        lockCanvas.SetActive(false);
    }

    void Update()
    {
        if (unlocked.safe2 == true)
        {
            safeOpen.SetActive(true);
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