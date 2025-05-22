using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Scriptable Objects/Drawers")]

public class OpenedDrawersList : ScriptableObject
{
    public List<bool> openedDrawers = new List<bool>();

    public void ResetList()
    {
        for (int i = 0; i < openedDrawers.Count; i++)
            openedDrawers[i] = false;
    }
}