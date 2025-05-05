using UnityEngine;

public class Badge : MonoBehaviour
{
    public Containers unlocked;
    public GameObject doctorsRoomDoor, badgeItem;

    void Update()
    {
        if (unlocked.badge == false)
        {
            doctorsRoomDoor.GetComponent<BoxCollider2D>().enabled = false;
            badgeItem.SetActive(true);
        }
        else
        {
            doctorsRoomDoor.GetComponent<BoxCollider2D>().enabled = true;
            badgeItem.SetActive(false);
        }
    }

    void OnMouseDown()
    {
        unlocked.badge = true;
    }
}