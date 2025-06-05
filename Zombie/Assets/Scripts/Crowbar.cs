using UnityEngine;

public class Crowbar : MonoBehaviour
{
    public DialogueTrigger trigger;

    public Containers unlocked;
    public GameObject crowbarItem;

    public AudioSource audio;

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
        audio.Play();

        unlocked.crowbar = true;

        trigger.TriggerDialogue();
    }
}