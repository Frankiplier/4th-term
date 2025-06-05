using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    public List<AudioClip> idleClips, attackClips;
    public AudioSource audioSource;

    private HP hp;
    public Animator animator;
    private ZombieSpawner.ZombieAnimationSet animationSet;

    public bool hasBeenShot = false;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        int r = Random.Range(0, idleClips.Count);
        AudioClip clip = idleClips[r];
        audioSource.clip = clip;
        audioSource.Play();
    }

    void Update()
    {
        if (hp == null)
        {
            hp = GameObject.FindGameObjectWithTag("Interface")?.GetComponent<HP>();
        }
    }

    public void SetAnimationSet(ZombieSpawner.ZombieAnimationSet set)
    {
        animationSet = set;
        animator.Play(animationSet.form1StateName);

        StartCoroutine(ChangeForm());
    }

    IEnumerator ChangeForm()
    {
        yield return new WaitForSeconds(7f);

        if (hasBeenShot == true) yield break;

        CameraController camController = Camera.main.GetComponent<CameraController>();

        if (camController != null)
        {
            camController.allowMovement = false;
            Camera.main.transform.position = new Vector3(transform.position.x, Camera.main.transform.position.y, Camera.main.transform.position.z);
            camController.SetCameraX(transform.position.x);
        }

        animator.Play(animationSet.form2StateName);

        int r = Random.Range(0, attackClips.Count);
        AudioClip clip = attackClips[r];
        audioSource.clip = clip;
        audioSource.Play();

        yield return new WaitForSeconds(1.5f);

        hp.RemoveHeart();

        if (camController != null)
        {
            camController.allowMovement = true;
        }

        Destroy(gameObject);
    }
}