using UnityEngine;
using System.Collections;

public class Dish : MonoBehaviour
{
    public DialogueTrigger trigger;

    public Containers unlocked;
    public GameObject dishItem;

    private SpriteRenderer spriteRenderer;

    public AudioSource audio;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (unlocked.dish == false)
        {
            dishItem.SetActive(true);
        }
        else
        {
            dishItem.SetActive(false);
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

        unlocked.dish = true;
        trigger.TriggerDialogue();
    }
}