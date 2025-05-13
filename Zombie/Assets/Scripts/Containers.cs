using UnityEngine;

[CreateAssetMenu(menuName = "Containers")]
public class Containers : ScriptableObject
{
    public bool gun = false, keys = false, card = false, safe1 = false, safe2 = false, power = false, crowbar = false, dish = false;

    public void ResetBools()
    {
        gun = false;
        keys = false;
        card = false;
        safe1 = false;
        safe2 = false;
        power = false;
        crowbar = false;
        dish = false;
    }
}