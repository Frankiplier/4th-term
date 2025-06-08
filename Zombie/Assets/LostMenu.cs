using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LostMenu : MonoBehaviour
{
    public static LostMenu Instance;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }

        else
        {
            Instance = this;

            if (SceneManager.GetActiveScene().name != "MainMenu")
            {
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }

    void Start()
    {
        gameObject.SetActive(false);
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
        
        CameraFade.Instance.TriggerFade();

        while (CameraFade.Instance.IsFading())
        {
            yield return null;
        }

        SceneManager.LoadScene(sceneIndex);
    }
}
