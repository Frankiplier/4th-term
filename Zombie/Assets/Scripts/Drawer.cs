using UnityEngine;

public class Drawer : MonoBehaviour
{
    public DialogueTrigger empty, full;

    public GameObject drawerClosed, drawerOpen, holder;
    public bool isOpen = false;

    public AudioSource audio;

    void Start()
    {
        drawerClosed.SetActive(true);
        drawerOpen.SetActive(false);
    }

    void OnMouseDown()
    {
        drawerClosed.SetActive(false);
        drawerOpen.SetActive(true);

        if (isOpen == false) audio.Play();

        isOpen = true;

        if (holder.transform.childCount > 0)
        {
            full.TriggerDialogue();
        }
        else
        {
            empty.TriggerDialogue();
        }
    }
}
