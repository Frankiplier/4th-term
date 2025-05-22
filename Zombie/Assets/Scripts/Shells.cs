using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Shells")]

public class PickedShellsList : ScriptableObject
{
    public List<bool> pickedUpShells = new List<bool>();

    public void ResetList()
    {
        for (int i = 0; i < pickedUpShells.Count; i++)
            pickedUpShells[i] = false;
    }
}