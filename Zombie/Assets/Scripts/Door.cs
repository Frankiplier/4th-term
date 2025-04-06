using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    public string sceneName;

    void OnMouseDown()
    {
        SceneManager.LoadScene(sceneName);
    }
}
