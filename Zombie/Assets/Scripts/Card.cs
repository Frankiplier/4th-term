using UnityEngine;

public class Card : MonoBehaviour
{
    public DialogueTrigger trigger;

    public Containers unlocked;
    public GameObject cardItem;

    void Update()
    {
        if (unlocked.card == false)
        {
            cardItem.SetActive(true);
        }
        else
        {
            cardItem.SetActive(false);
        }
    }

    void OnMouseDown()
    {
        unlocked.card = true;
        
        trigger.TriggerDialogue();
    }
}