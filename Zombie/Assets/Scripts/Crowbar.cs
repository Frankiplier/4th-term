using UnityEngine;

public class Crowbar : MonoBehaviour
{
    public DialogueTrigger trigger;

    public Containers unlocked;
    public GameObject crowbarItem;

    void Update()
    {
        if (unlocked.crowbar == false)
        {
            crowbarItem.SetActive(true);
        }
        else
        {
            crowbarItem.SetActive(false);
        }
    }

    void OnMouseDown()
    {
        unlocked.crowbar = true;

        trigger.TriggerDialogue();
    }
}