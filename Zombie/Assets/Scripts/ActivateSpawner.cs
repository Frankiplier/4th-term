using UnityEngine;

public class ActivateSpawner : MonoBehaviour
{
    public GameObject zombieSpawner;
    public Containers unlocked;

    void Update()
    {
        if (unlocked.gun == true)
        {
            zombieSpawner.SetActive(true);
        }
        else
            zombieSpawner.SetActive(false);
    }
}
