using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lock : MonoBehaviour
{
    public Containers unlocked;
    public GameObject safe1Open, safe2Open, lockCanvas;
    private bool isUnlocked = false, isVisible = false;

    void Start()
    {
        safe1Open.SetActive(false);
        safe2Open.SetActive(false);
        lockCanvas.SetActive(false);
    }

    void Update()
    {
        if (unlocked.safe1 == true)
        {
            isUnlocked = true;
            safe1Open.SetActive(true);
        }
        else if (unlocked.safe2 == true)
        {
            isUnlocked = true;
            safe2Open.SetActive(true);
        }
    }

    void OnMouseDown()
    {
        if (isVisible == false && isUnlocked == false)
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