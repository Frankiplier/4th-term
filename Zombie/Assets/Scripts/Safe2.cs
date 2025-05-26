using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Safe2 : MonoBehaviour
{
    public Containers unlocked;
    public GameObject safeOpen, lockBG;
    private bool isVisible = false;

    void Start()
    {
        safeOpen.SetActive(false);
        lockBG.SetActive(false);
    }

    void Update()
    {
        if (unlocked.safe2 == true)
        {
            safeOpen.SetActive(true);
            lockBG.SetActive(false);
        }
    }

    void OnMouseDown()
    {
        if (isVisible == false && unlocked.safe2 == false)
        {
            lockBG.SetActive(true);
            isVisible = true;
        }
        else
        {
            lockBG.SetActive(false);
            isVisible = false;
        }
    }
}