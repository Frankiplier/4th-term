using UnityEngine;

public class Vitamin : MonoBehaviour
{
    public DialogueTrigger trigger;

    [SerializeField] PickedHeartsList pickedHearts;
    [SerializeField] int vitaminIndex;

    private HP hp;

    void Awake()
    {
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
            hp.AddHeart();
            pickedHearts.pickedUpHearts[vitaminIndex] = true;
            Destroy(gameObject);
        }
        else
        {
            trigger.TriggerDialogue();
        }
    }
}