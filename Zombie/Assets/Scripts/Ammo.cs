using UnityEngine;

public class Ammo : MonoBehaviour
{
    public DialogueTrigger trigger;

    [SerializeField] PickedShellsList pickedShells;
    [SerializeField] int shellIndex;

    private Interface ui;

    void Awake()
    {
        if (pickedShells.pickedUpShells[shellIndex])
        {
            Destroy(gameObject);
            return;
        }
    }

    void Update()
    {
        if (ui == null)
        {
            ui = GameObject.FindGameObjectWithTag("Interface")?.GetComponent<Interface>();
        }
    }

    void OnMouseDown()
    {
        AddAmmo();
    }

    void AddAmmo()
    {
        ui.shellsCount += 1;
        ui.shellsText.text = ui.shellsCount.ToString();
        pickedShells.pickedUpShells[shellIndex] = true;
        Destroy(gameObject);

        trigger.TriggerDialogue();
    }
}