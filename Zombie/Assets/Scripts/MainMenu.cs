using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public CodeGenerator codeGenerator;
    
    [SerializeField] PickedShellsList shellsList;
    [SerializeField] PickedHeartsList heartsList;
    [SerializeField] CollectibleSpawnRegistry registry;
    [SerializeField] Containers containers;


    void Start()
    {
        PlayerPrefs.DeleteAll();
        
        if (Time.timeScale == 0f)
        {
            Time.timeScale = 1f;
        }

        CameraFade.Instance.StartFadeIn();
        
        MusicManager.Instance.PlayMusic("MainMenu");

        codeGenerator.GenerateCodes();

        shellsList.ResetList();
        heartsList.ResetList();
        registry.ClearAll();
        containers.ResetBools();
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
        CameraFade.Instance.StartFadeOut();

        yield return new WaitUntil(() => CameraFade.Instance.IsFading());
        yield return new WaitUntil(() => !CameraFade.Instance.IsFading());

        if (sceneIndex >= 0)
        {
            SceneManager.LoadScene(sceneIndex);

            MusicManager.Instance.PlayMusic("Theme");
        }

        else
        {
            Application.Quit();
        }
    }
}