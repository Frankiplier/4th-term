using UnityEngine;
using UnityEngine.SceneManagement;

public class Flashlight : MonoBehaviour
{
    public static Flashlight Instance;

    public DialogueTrigger trigger;
    public FollowMouse followMouseScript;

    public GameObject lightCone;
    public float maxBattery, currentBattery, dischargeRate;
    public bool isCharging = false;
    private const string BatteryKey = "CurrentBattery";

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
        if (SceneManager.GetActiveScene().name != "MainMenu")
        {
            currentBattery = PlayerPrefs.GetFloat(BatteryKey, maxBattery);
        }

        else
        {
            currentBattery = maxBattery;
        }

        transform.localScale = new Vector3(currentBattery, currentBattery, 1f);
    }

    void Update()
    {
        if (!isCharging && !PauseMenu.Instance.isPaused && !CameraFade.Instance.IsFading())
        {
            lightCone.SetActive(true);

            currentBattery -= dischargeRate * Time.deltaTime;
            currentBattery = Mathf.Max(currentBattery, 0f);

            transform.localScale = new Vector3(currentBattery, currentBattery, 1f);

            if (currentBattery <= maxBattery / 2 && currentBattery >= maxBattery / 2 - 2f)
            {
                trigger.TriggerDialogue();
            }
            else if (currentBattery <= 0f)
            {
                GameOver();
            }

            PlayerPrefs.SetFloat(BatteryKey, currentBattery);
        }
        else if (PauseMenu.Instance.isPaused)
        {
            lightCone.SetActive(false);
        }

        if (SceneManager.GetActiveScene().name == "EndMenu")
            {
                Destroy(gameObject);
            }
    }

    public void RechargeBattery()
    {
        currentBattery = maxBattery;
        isCharging = false;

        PlayerPrefs.SetFloat(BatteryKey, currentBattery);
    }

    void GameOver()
    {
        Debug.Log("You lost!");
    }

    void OnApplicationQuit()
    {
        PlayerPrefs.DeleteKey(BatteryKey);
    }
}