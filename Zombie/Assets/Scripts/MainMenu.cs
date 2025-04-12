using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] PickedShellsList shellsList;

    void Start()
    {
        shellsList.ResetList();
    }

    public void StartGame()
    {
        StartCoroutine(FadeBeforeTransition(1));
    }

    public void ExitGame()
    {
        StartCoroutine(FadeBeforeTransition(-1));
    }

    private IEnumerator FadeBeforeTransition(int sceneIndex)
    {
        CameraFade.Instance.TriggerFade();

        while (CameraFade.Instance.IsFading())
        {
            yield return null;
        }

        if (sceneIndex >= 0)
        {
            SceneManager.LoadScene(sceneIndex);
        }

        else
        {
            Application.Quit();
        }
    }
}