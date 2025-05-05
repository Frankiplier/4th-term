using UnityEngine;

public class Jacket : MonoBehaviour
{
    public Containers unlocked;
    public GameObject jacketItem;

    void Update()
    {
        if (unlocked.jacket == false)
        {
            jacketItem.SetActive(true);
        }
        else
        {
            jacketItem.SetActive(false);
        }
    }

    void OnMouseDown()
    {
        unlocked.jacket = true;
    }
}