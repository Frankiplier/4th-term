using System.Collections;
using UnityEngine;

public class Zombie : MonoBehaviour
{
     private HP hp;

    private SpriteRenderer spriteRenderer;
    private ZombieSpawner.ZombieSpriteSet spriteSet;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (hp == null)
        {
            hp = GameObject.FindGameObjectWithTag("Interface")?.GetComponent<HP>();
        }
    }

    public void SetSpriteSet(ZombieSpawner.ZombieSpriteSet set)
    {
        spriteSet = set;
        spriteRenderer.sprite = spriteSet.form1;
        StartCoroutine(ChangeForm());
    }

    IEnumerator ChangeForm()
    {
        yield return new WaitForSeconds(5f);

        spriteRenderer.sprite = spriteSet.form2;
        hp.RemoveHeart();

        yield return new WaitForSeconds(1f);

        // logic for animation
        Destroy(gameObject);
    }
}