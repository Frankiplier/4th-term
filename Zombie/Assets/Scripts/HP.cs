using UnityEngine;

public class HP : MonoBehaviour
{
    public DialogueTrigger damage, heal;

    public int currentHP = 3, maxHP = 3;

    public GameObject lostMenu;

    public void RemoveHeart()
    {
        if (currentHP <= 0) return;

        currentHP--;
        Interface.Instance.heartImages[currentHP].enabled = false;

        damage.TriggerDialogue();

        if (currentHP == 0)
        {
            GameOver();
        }
    }

    public void AddHeart()
    {
        if (currentHP >= maxHP) return;

        Interface.Instance.heartImages[currentHP].enabled = true;
        currentHP++;

        heal.TriggerDialogue();
    }

    void GameOver()
    {
        lostMenu.SetActive(true);
    }
}