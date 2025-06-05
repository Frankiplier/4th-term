using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class EndMenu : MonoBehaviour
{
    [SerializeField] Containers containers;
    public DialogueTrigger allItems, oneItem, noItems;

    void Start()
    {
        MusicManager.Instance.PlayMusic("MainMenu");
        
        StartCoroutine(TriggerDialogueWithDelay());
    }

    private IEnumerator TriggerDialogueWithDelay()
    {
        yield return new WaitForSeconds(1f);

        if (containers.keys && containers.dish)
        {
            allItems.TriggerDialogue();
        }
        else if (containers.keys || containers.dish)
        {
            oneItem.TriggerDialogue();
        }
        else
        {
            noItems.TriggerDialogue();
        }
    }

    public void MainMenu()
    {
        StartCoroutine(FadeBeforeTransition(0));
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
