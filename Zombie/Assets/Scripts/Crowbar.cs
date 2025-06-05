using UnityEngine;
using System.Collections;

public class Crowbar : MonoBehaviour
{
    public DialogueTrigger trigger;

    public Containers unlocked;
    public GameObject crowbarItem;

    private SpriteRenderer spriteRenderer;

    public AudioSource audio;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

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
        StartCoroutine(Wait());
    }

    private IEnumerator Wait()
    {
        audio.Play();

        spriteRenderer.sprite = null;

        yield return new WaitForSeconds(1f);

        unlocked.crowbar = true;
        trigger.TriggerDialogue();
    }
}