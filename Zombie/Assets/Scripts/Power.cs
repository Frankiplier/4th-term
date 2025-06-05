using UnityEngine;

public class Power : MonoBehaviour
{
    public DialogueTrigger trigger;
    
    public Containers unlocked;
    public GameObject powerOnItem;

    public AudioSource audio;

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
        audio.Play();
        
        unlocked.power = true;

        trigger.TriggerDialogue();
    }
}