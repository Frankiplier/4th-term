using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    public DialogueTrigger trigger;
    
    public Containers unlocked;
    public string sceneName;

    void OnMouseDown()
    {
        if (sceneName == "Hallway" && unlocked.gun == false)
        {
            trigger.TriggerDialogue();
            Debug.Log("Dialogue triggered");
            return;
        }
        if (sceneName == "Room" && unlocked.card == false)
        {
            trigger.TriggerDialogue();
            Debug.Log("Dialogue triggered");
            return;
        }
        else if (sceneName == "Storage" && unlocked.card == false)
        {
            trigger.TriggerDialogue();
            Debug.Log("Dialogue triggered");
            return;
        }
        if (sceneName == "Elevator" && unlocked.power == false)
        {
            trigger.TriggerDialogue();
            Debug.Log("Dialogue triggered");
            return;
        }
        if (sceneName == "Restaurant" && unlocked.crowbar == false)
        {
            trigger.TriggerDialogue();
            Debug.Log("Dialogue triggered");
            return;
        }

        StartCoroutine(FadeBeforeTransition(sceneName));
    }

    private IEnumerator FadeBeforeTransition(string sceneName)
    {
        CameraFade.Instance.TriggerFade();

        while (CameraFade.Instance.IsFading())
        {
            yield return null;
        }

        SceneManager.LoadScene(sceneName);
    }
}