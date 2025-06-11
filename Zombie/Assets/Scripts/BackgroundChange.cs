using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundChange : MonoBehaviour
{
    public string sceneName;
    public bool isOpen = false;

    public SpriteRenderer sr;
    public Sprite[] spriteArray;

    public Containers unlocked;

    void Start()
    {
        if (sceneName == "Hallway")
        {
            if (unlocked.power == true)
            {
                sr.sprite = spriteArray[1];
            }
            else
            {
                sr.sprite = spriteArray[0];
            }
        }

        if (isOpen == true)
        {
            sr.sprite = spriteArray[1];
        }
    }

    void OnMouseDown()
    {
        if (sceneName == "Reception")
        {
            if (unlocked.crowbar == true)
            {
                sr.sprite = spriteArray[1];
                isOpen = true;
            }
        }
    }
}