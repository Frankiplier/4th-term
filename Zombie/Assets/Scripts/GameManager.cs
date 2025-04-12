using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject flashlightPrefab;
    public GameObject gunPrefab;
    public GameObject interfacePrefab;

    void Start()
    {
        if (SceneManager.GetActiveScene().name != "MainMenu" && Flashlight.Instance == null)
        {
            Instantiate(flashlightPrefab);
        }

        if (SceneManager.GetActiveScene().name != "MainMenu" && Gun.Instance == null)
        {
            Instantiate(gunPrefab);
        }

        if (SceneManager.GetActiveScene().name != "MainMenu" && Interface.Instance == null)
        {
            Instantiate(interfacePrefab);
        }
    }
}