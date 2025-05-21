using UnityEngine;

public class Power : MonoBehaviour
{
    public DialogueTrigger trigger;
    
    public Containers unlocked;

    // some mini-game here later???

    void OnMouseDown()
    {
        unlocked.power = true;

        trigger.TriggerDialogue();
    }
}