using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Interface : MonoBehaviour
{
    public static Interface Instance;

    public TMP_Text shellsText;
    public int shellsCount = 0;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }

        else
        {
            Instance = this;

            if (SceneManager.GetActiveScene().name != "MainMenu")
            {
                DontDestroyOnLoad(gameObject);
            }

            else
            {
                Destroy(gameObject);
            }
        }
    }

    void Start()
    {
        shellsText.text = shellsCount.ToString();
    }

}
