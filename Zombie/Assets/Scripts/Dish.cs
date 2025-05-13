using UnityEngine;

public class Dish : MonoBehaviour
{
    public Containers unlocked;
    public GameObject dishItem;

    void Update()
    {
        if (unlocked.dish == false)
        {
            dishItem.SetActive(true);
        }
        else
        {
            dishItem.SetActive(false);
        }
    }

    void OnMouseDown()
    {
        unlocked.dish = true;
    }
}