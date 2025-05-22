using UnityEngine;

public class Drawer : MonoBehaviour
{
    public DialogueTrigger empty, full;

    public GameObject drawerClosed, drawerOpen;
    [SerializeField] OpenedDrawersList checkedDrawers;
    [SerializeField] int index;

    void Start()
    {
        drawerClosed.SetActive(true);
        drawerOpen.SetActive(false);
    }

    void Update()
    {
        if (checkedDrawers.openedDrawers[index] == true)
        {
            drawerClosed.SetActive(false);
            drawerOpen.SetActive(true);
        }
    }

    void OnMouseDown()
    {
        drawerClosed.SetActive(false);
        drawerOpen.SetActive(true);

        checkedDrawers.openedDrawers[index] = true;

        if (drawerOpen.transform.childCount > 0)
        {
            full.TriggerDialogue();
        }
        else
        {
            empty.TriggerDialogue();
        }
    }
}
