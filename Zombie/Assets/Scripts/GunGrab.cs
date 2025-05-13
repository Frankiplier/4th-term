using UnityEngine;

public class GunGrab : MonoBehaviour
{
    public Containers unlocked;
    public GameObject gunItem, gunPrefab;

    void Update()
    {
        if (unlocked.gun == false)
        {
            gunItem.SetActive(true);
        }
        else
        {
            Instantiate(gunPrefab);
            gunItem.SetActive(false);
        }
    }

    void OnMouseDown()
    {
        unlocked.gun = true;
    }
}
