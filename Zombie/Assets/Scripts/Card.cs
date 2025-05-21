using UnityEngine;

public class Card : MonoBehaviour
{
    public DialogueTrigger trigger;

    public Containers unlocked;
    public GameObject room, storage, cardItem;

    void Update()
    {
        if (unlocked.card == false)
        {
            room.GetComponent<BoxCollider2D>().enabled = false;
            storage.GetComponent<BoxCollider2D>().enabled = false;
            cardItem.SetActive(true);
        }
        else
        {
            room.GetComponent<BoxCollider2D>().enabled = true;
            storage.GetComponent<BoxCollider2D>().enabled = true;
            cardItem.SetActive(false);
        }
    }

    void OnMouseDown()
    {
        unlocked.card = true;
        
        trigger.TriggerDialogue();
    }
}