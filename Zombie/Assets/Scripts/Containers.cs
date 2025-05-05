using UnityEngine;

[CreateAssetMenu(menuName = "Containers")]
public class Containers : ScriptableObject
{
    public bool hallway2 = false;

    public void ResetBools()
    {
        hallway2 = false;
    }
}