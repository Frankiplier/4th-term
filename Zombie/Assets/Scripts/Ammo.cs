using UnityEngine;

public class Ammo : MonoBehaviour
{
    public GameObject shell;
    [SerializeField] PickedShellsList pickedShells;
    [SerializeField] int index;

    private Interface ui;

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
        pickedShells.pickedUpShells[index] = true;
        shell.SetActive(false);
    }

    void Awake()
    {
        if (pickedShells.pickedUpShells[index])
        {
            Destroy(gameObject);
            return;
        }
    }
}