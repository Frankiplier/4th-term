using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundChange : MonoBehaviour
{
    public string sceneName;

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
    }

    void Update()
    {
        if (sceneName == "Reception" && unlocked.door == true)
        {
            sr.sprite = spriteArray[1];
        }
    }
}