using UnityEngine;

[CreateAssetMenu(menuName = "Containers")]
public class Containers : ScriptableObject
{
    public bool keys = false, badge = false, codePanel = false, power = false, crowbar = false, jacket = false;

    public void ResetBools()
    {
        keys = false;
        badge = false;
        codePanel = false;
        power = false;
        crowbar = false;
        jacket = false;
    }
}