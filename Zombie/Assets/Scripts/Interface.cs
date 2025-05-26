using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Interface : MonoBehaviour
{
    public static Interface Instance;
    [SerializeField] CodeGenerator generatedCode;

    public Image[] heartImages;
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
        shellsText.text = "x " + shellsCount.ToString();
    }

    void Update()
    {
        if (SceneManager.GetActiveScene().name == "EndMenu" || SceneManager.GetActiveScene().name == "MainMenu")
        {
            Destroy(gameObject);
        }
    }
}