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
        CameraFade.Instance.StartFadeOut();

        yield return new WaitUntil(() => CameraFade.Instance.IsFading());
        yield return new WaitUntil(() => !CameraFade.Instance.IsFading());

        // MusicManager.Instance.PlayMusic("Theme");

        SceneManager.LoadScene(sceneName);

        audio2.Play();
    }
}