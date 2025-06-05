using UnityEngine;
using System.Collections;

public class Keys : MonoBehaviour
{
    public DialogueTrigger trigger;

    public Containers unlocked;
    public GameObject keysItem;

    private SpriteRenderer spriteRenderer;

    public AudioSource audio;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (unlocked.keys == false)
        {
            keysItem.SetActive(true);
        }
        else
        {
            keysItem.SetActive(false);
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
        
        unlocked.keys = true;
        trigger.TriggerDialogue();
    }
}