using UnityEngine;

public class HP : MonoBehaviour
{
    public int currentHP = 3, maxHP = 3;

    void Update()
    {
        // debug for now
        if (Input.GetKeyDown(KeyCode.A))
        {
            RemoveHeart();
        }
    }

    public void RemoveHeart()
    {
        if (currentHP <= 0) return;

        currentHP--;
        Interface.Instance.heartImages[currentHP].enabled = false;

        if (currentHP == 0)
        {
            Debug.Log("Game Over");
        }
    }

    public void AddHeart()
    {
        if (currentHP >= maxHP) return;

        Interface.Instance.heartImages[currentHP].enabled = true;
        currentHP++;
    }
}