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

    void OnMouseDown()
    {
        drawerClosed.SetActive(false);
        drawerOpen.SetActive(true);

        if (drawerOpen.transform.childCount > 0)
        {
            full.TriggerDialogue();
        }
        else
        {
            empty.TriggerDialogue();
        }
    }
    
    void Awake()
    {
        if (checkedDrawers.openedDrawers[index])
        {
            Destroy(gameObject);
            return;
        }
    }
}
