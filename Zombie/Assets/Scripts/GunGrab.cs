using UnityEngine;
using System.Collections;

public class GunGrab : MonoBehaviour
{
    public DialogueTrigger trigger;

    public Containers unlocked;
    public GameObject gunItem, gunPrefab;

    private SpriteRenderer spriteRenderer;

    public AudioSource audio;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (unlocked.gun == false)
        {
            gunItem.SetActive(true);
        }
        else
        {
            Instantiate(gunPrefab);
            gunItem.SetActive(false);
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

        unlocked.gun = true;
        trigger.TriggerDialogue();
    }
}
