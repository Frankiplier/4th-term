using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Interface : MonoBehaviour
{
    public static Interface Instance;
    [SerializeField] CodeGenerator generatedCode;
    [SerializeField] Containers unlocked;

    public Image[] heartImages;
    public TMP_Text shellsText;
    public int shellsCount = 0;
    public GameObject card, keys, crowbar, dish;

    public DialogueTrigger tutorial;

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

        if (tutorial != null && tutorial.dialogue != null && tutorial.dialogue.dialogueLines.Count > 0)
        {
            tutorial.TriggerDialogue();
        }

        if (Time.timeScale == 0f)
        {
            Time.timeScale = 1f;
        }
    }

    void Update()
    {
        if (SceneManager.GetActiveScene().name == "EndMenu" || SceneManager.GetActiveScene().name == "MainMenu")
        {
            Destroy(gameObject);
        }

        if (unlocked.card == false)
        {
            card.SetActive(false);
        }
        else card.SetActive(true);

        if (unlocked.keys == false)
        {
            keys.SetActive(false);
        }
        else keys.SetActive(true);

        if (unlocked.crowbar == false)
        {
            crowbar.SetActive(false);
        }
        else crowbar.SetActive(true);

        if (unlocked.dish == false)
        {
            dish.SetActive(false);
        }
        else dish.SetActive(true);
    }
}