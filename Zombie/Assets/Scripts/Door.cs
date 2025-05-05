using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    public Containers unlocked;
    public string sceneName;

    void OnMouseDown()
    {
        if (sceneName == "Electrical" && unlocked.keys == false) return;
        if (sceneName == "Elevator" && unlocked.power == false) return;
        if (sceneName == "DressingRoom" && unlocked.crowbar == false) return;
        if (sceneName == "WinMenu" && unlocked.jacket == false) return;

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