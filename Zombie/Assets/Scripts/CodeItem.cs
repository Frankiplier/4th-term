using UnityEngine;

public class CodeItem : MonoBehaviour
{
    public GameObject codePaper;
    private bool isVisible = false;

    public AudioSource audio;
    public CameraController cam;

    void Start()
    {
        codePaper.SetActive(false);
    }

    public void CloseUI()
    {
        cam.allowMovement = true;
        
        codePaper.SetActive(false);
        isVisible = false;
    }

    void OnMouseDown()
    {
        if (isVisible == false)
        {
            audio.Play();
            cam.allowMovement = false;

            codePaper.SetActive(true);
            isVisible = true;
        }
        else
        {
            cam.allowMovement = true;

            codePaper.SetActive(false);
            isVisible = false;
        }
    }
}