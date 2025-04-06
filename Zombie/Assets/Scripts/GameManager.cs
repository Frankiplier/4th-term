using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject flashlightPrefab;

    void Start()
    {
        if (SceneManager.GetActiveScene().name != "MainMenu" && Flashlight.Instance == null)
        {
            Instantiate(flashlightPrefab);
        }
    }
}