using UnityEngine;

public class Keys : MonoBehaviour
{
    public DialogueTrigger trigger;
    
    public Containers unlocked;
    public GameObject keysItem;

    void Update()
    {
        if (unlocked.keys == false)
        {
            keysItem.SetActive(true);
        }
        else
        {
            keysItem.SetActive(false);
        }
    }

    void OnMouseDown()
    {
        unlocked.keys = true;

        trigger.TriggerDialogue();
    }
}