using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    public DialogueTrigger trigger, open;
    public BackgroundChange bg;
    
    public Containers unlocked;
    public string sceneName;

    public AudioSource audio;

    void OnMouseDown()
    {
        if (sceneName == "Hallway" && unlocked.gun == false)
        {
            trigger.TriggerDialogue();
            return;
        }

        if (sceneName == "Room" && unlocked.card == false)
        {
            trigger.TriggerDialogue();
            return;
        }

        if (sceneName == "Storage" && unlocked.card == false)
        {
            trigger.TriggerDialogue();
            return;
        }

        if (sceneName == "Reception" && unlocked.power == false)
        {
            trigger.TriggerDialogue();
            return;
        }

        if (sceneName == "Restaurant" && unlocked.crowbar == false)
        {
            trigger.TriggerDialogue();
            return;
        }
        else if (sceneName == "Restaurant" && unlocked.crowbar == true && unlocked.door == false)
        {
            unlocked.door = true;
            audio.Play();
            open.TriggerDialogue();
            return;
        }

        if (Flashlight.Instance.isCharging) return;

        StartCoroutine(FadeBeforeTransition(sceneName));
    }

    private IEnumerator FadeBeforeTransition(string sceneName)
    {
        CameraFade.Instance.StartFadeOut();

        yield return new WaitUntil(() => CameraFade.Instance.IsFading());
        yield return new WaitUntil(() => !CameraFade.Instance.IsFading());

        if (sceneName == "Elevator")
        {
            MusicManager.Instance.PlayMusic("Elevator");
        }

        SceneManager.LoadScene(sceneName);
    }
}