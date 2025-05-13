using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject flashlightPrefab;
    public GameObject interfacePrefab;

    void Start()
    {
        if (SceneManager.GetActiveScene().name != "MainMenu" && Flashlight.Instance == null)
        {
            Instantiate(flashlightPrefab);
        }

        if (SceneManager.GetActiveScene().name != "MainMenu" && Interface.Instance == null)
        {
            Instantiate(interfacePrefab);
        }
    }
}