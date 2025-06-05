using UnityEngine;

public class Card : MonoBehaviour
{
    public DialogueTrigger trigger;

    public Containers unlocked;
    public GameObject cardItem;

    public AudioSource audio;

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
        audio.Play();

        unlocked.card = true;

        trigger.TriggerDialogue();
    }
}