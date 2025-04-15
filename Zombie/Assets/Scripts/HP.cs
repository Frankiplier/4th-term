using UnityEngine;

public class HP : MonoBehaviour
{
    private int currentHP = 3, maxHP = 3;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            RemoveHeart();
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            AddHeart();
        }
    }

    void RemoveHeart()
    {
        if (currentHP <= 0) return;

        currentHP--;
        Interface.Instance.heartImages[currentHP].enabled = false;

        if (currentHP == 0)
        {
            Debug.Log("Game Over");
        }
    }

    void AddHeart()
    {
        if (currentHP >= maxHP) return;

        Interface.Instance.heartImages[currentHP].enabled = true;
        currentHP++;
    }
}