using UnityEngine;

[CreateAssetMenu(menuName = "Containers")]
public class Containers : ScriptableObject
{
    public bool badge = false, codePanel = false, keys = false, crowbar = false, jacket = false;

    public void ResetBools()
    {
        badge = false;
        codePanel = false;
        keys = false;
        crowbar = false;
        jacket = false;
    }
}