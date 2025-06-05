using UnityEngine;

public class CodeItem : MonoBehaviour
{
    public GameObject codePaper;
    private bool isVisible = false;

    public AudioSource audio;

    void Start()
    {
        codePaper.SetActive(false);
    }

    void OnMouseDown()
    {
        if (isVisible == false)
        {
            audio.Play();

            codePaper.SetActive(true);
            isVisible = true;
        }
        else
        {
            codePaper.SetActive(false);
            isVisible = false;
        }
    }
}