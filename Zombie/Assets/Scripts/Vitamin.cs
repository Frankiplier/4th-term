using UnityEngine;

public class Vitamin : MonoBehaviour
{
    public GameObject vitamin;
    [SerializeField] PickedHeartsList pickedHearts;
    [SerializeField] int index;

    private Interface ui;
    private HP hp;

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
            vitamin.SetActive(false);
        }
    }

    void Awake()
    {
        if (pickedHearts.pickedUpHearts[index])
        {
            Destroy(gameObject);
            return;
        }
    }
}