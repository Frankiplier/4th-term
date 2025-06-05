using UnityEngine;
using System.Collections;

public class Card : MonoBehaviour
{
    public DialogueTrigger trigger;

    public Containers unlocked;
    public GameObject cardItem;

    private SpriteRenderer spriteRenderer;

    public AudioSource audio;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (unlocked.card == false)
        {
            cardItem.SetActive(true);
        }
        else
        {
            cardItem.SetActive(false);
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

        unlocked.card = true;
        trigger.TriggerDialogue();
    }
}