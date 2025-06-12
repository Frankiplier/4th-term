using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static PauseMenu Instance;

    public GameObject pauseMenu;
    public bool isPaused = false;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        isPaused = false;
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !CameraFade.Instance.IsFading())
        {
            PauseGame();
        }
    }

    void PauseGame()
    {
        Time.timeScale = 0f;
        isPaused = true;
        pauseMenu.SetActive(true); 
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        isPaused = false;
        pauseMenu.SetActive(false);
    }

    public void ExitToMainMenu()
    {
        StartCoroutine(FadeBeforeTransition(0));
    }

    public void ResetPauseState()
    {
        isPaused = false;
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
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