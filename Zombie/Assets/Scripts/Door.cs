using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    public Containers unlocked;
    public string sceneName;

    void OnMouseDown()
    {
        if (sceneName == "Hallway" && unlocked.gun == false) return;
        if (sceneName == "Room" && unlocked.card == false) return;
        if (sceneName == "Storage" && unlocked.card == false) return;
        if (sceneName == "Elevator" && unlocked.power == false) return;
        if (sceneName == "Restaurant" && unlocked.crowbar == false) return;

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