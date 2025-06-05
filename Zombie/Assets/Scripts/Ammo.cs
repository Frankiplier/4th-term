using UnityEngine;
using System.Collections;

public class Ammo : MonoBehaviour
{
    public DialogueTrigger trigger;

    [SerializeField] PickedShellsList pickedShells;
    [SerializeField] int shellIndex;

    private SpriteRenderer spriteRenderer;

    public AudioSource audio;

    private Interface ui;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

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
        StartCoroutine(AddAmmo());
    }

    private IEnumerator AddAmmo()
    {
        audio.Play();

        spriteRenderer.sprite = null;

        ui.shellsCount += 1;
        ui.shellsText.text = ui.shellsCount.ToString();
        pickedShells.pickedUpShells[shellIndex] = true;

        yield return new WaitForSeconds(1f);

        Destroy(gameObject);
        trigger.TriggerDialogue();
    }
}