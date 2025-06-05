using UnityEngine;
using System.Collections;

public class Vitamin : MonoBehaviour
{
    public DialogueTrigger trigger;

    [SerializeField] PickedHeartsList pickedHearts;
    [SerializeField] int vitaminIndex;

    private SpriteRenderer spriteRenderer;

    public AudioSource audio;

    private HP hp;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (pickedHearts.pickedUpHearts[vitaminIndex])
        {
            Destroy(gameObject);
            return;
        }
    }

    void Update()
    {
        if (hp == null)
        {
            hp = GameObject.FindGameObjectWithTag("Interface")?.GetComponent<HP>();
        }
    }

    void OnMouseDown()
    {
        if (hp.currentHP < hp.maxHP)
        {
            StartCoroutine(AddHearts());
        }
        else
        {
            trigger.TriggerDialogue();
        }
    }
    
    private IEnumerator AddHearts()
    {
        audio.Play();

        spriteRenderer.sprite = null;
        
        hp.AddHeart();
        pickedHearts.pickedUpHearts[vitaminIndex] = true;

        yield return new WaitForSeconds(1f);

        Destroy(gameObject);
    }
}