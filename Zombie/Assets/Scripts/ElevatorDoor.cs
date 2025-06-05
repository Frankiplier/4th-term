using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ElevatorDoor : MonoBehaviour
{
    public string sceneName;
    public AudioSource audio1, audio2;

    void OnMouseDown()
    {
        StartCoroutine(FadeBeforeTransition(sceneName));
        audio1.Play();
    }

    private IEnumerator FadeBeforeTransition(string sceneName)
    {
        CameraFade.Instance.TriggerFade();

        while (CameraFade.Instance.IsFading())
        {
            yield return null;
        }

        MusicManager.Instance.PlayMusic("Theme");

        SceneManager.LoadScene(sceneName);

        audio2.Play();
    }
}