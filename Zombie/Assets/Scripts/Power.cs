using UnityEngine;

public class Power : MonoBehaviour
{
    public DialogueTrigger trigger;
    
    public Containers unlocked;
    public GameObject powerOnItem;

    void Update()
    {
        if (unlocked.power == false)
        {
            powerOnItem.SetActive(false);
        }
        else
        {
            powerOnItem.SetActive(true);
        }
    }

    void OnMouseDown()
    {
        unlocked.power = true;

        trigger.TriggerDialogue();
    }
}