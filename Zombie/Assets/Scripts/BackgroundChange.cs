using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundChange : MonoBehaviour
{
    public SpriteRenderer sr; 
    public Sprite[] spriteArray;

    public Containers unlocked;

    void Start()
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