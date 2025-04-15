using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Scriptable Objects/Hearts")]

public class PickedHeartsList : ScriptableObject
{
    public List<bool> pickedUpHearts = new List<bool>();

    public void ResetList()
    {
        for (int i = 0; i < pickedUpHearts.Count; i++)
            pickedUpHearts[i] = false;
    }
}