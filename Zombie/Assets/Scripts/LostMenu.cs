using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LostMenu : MonoBehaviour
{
    void Start()
    {
        gameObject.SetActive(false);
    }

    void OnEnable()
    {
        Time.timeScale = 0f;
    }

    void Update()
    {
        if (SceneManager.GetActiveScene().name == "EndMenu" || SceneManager.GetActiveScene().name == "MainMenu")
        {
            Destroy(gameObject);
        }
    }

    public void ExitToMainMenu()
    {
        Time.timeScale = 1f;

        StartCoroutine(FadeBeforeTransition(0));
    }

    private IEnumerator FadeBeforeTransition(int sceneIndex)
    {
        Time.timeScale = 1f;

        CameraFade.Instance.StartFadeOut();

        yield return new WaitUntil(() => CameraFade.Instance.IsFading());
        yield return new WaitUntil(() => !CameraFade.Instance.IsFading());

        SceneManager.LoadScene(sceneIndex);
    }
}
