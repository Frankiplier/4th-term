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

        CameraController camController = Camera.main.GetComponent<CameraController>();

        if (camController != null)
        {
            camController.allowMovement = false;

            Camera.main.transform.position = new Vector3(transform.position.x, Camera.main.transform.position.y, Camera.main.transform.position.z);
            camController.SetCameraX(transform.position.x);
        }

        Camera.main.transform.position = new Vector3(transform.position.x, Camera.main.transform.position.y, Camera.main.transform.position.z);

        spriteRenderer.sprite = spriteSet.form2;
        // logic for animation

        yield return new WaitForSeconds(3f);

        hp.RemoveHeart();

        if (camController != null)
        {
            camController.allowMovement = true;
        }

        Destroy(gameObject);
    }
}