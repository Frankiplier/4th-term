using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Safe1 : MonoBehaviour
{
    public Containers unlocked;
    public GameObject safeOpen, lockBG;
    private bool isVisible = false;

    public CameraController cam;

    void Start()
    {
        safeOpen.SetActive(false);
        lockBG.SetActive(false);
    }

    void Update()
    {
        if (unlocked.safe1 == true)
        {
            safeOpen.SetActive(true);
            lockBG.SetActive(false);
            isVisible = false;
        }
    }

    public void CloseUI()
    {
        cam.allowMovement = true;

        lockBG.SetActive(false);
        isVisible = false;
    }

    void OnMouseDown()
    {
        if (isVisible == false && unlocked.safe1 == false)
        {
            cam.allowMovement = false;

            lockBG.SetActive(true);
            isVisible = true;
        }
        // else
        // {
        //     cam.allowMovement = true;

        //     lockBG.SetActive(false);
        //     isVisible = false;
        // }
    }
}