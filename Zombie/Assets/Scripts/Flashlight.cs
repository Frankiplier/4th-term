using UnityEngine;
using UnityEngine.SceneManagement;

public class Flashlight : MonoBehaviour
{
    public static Flashlight Instance;

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
        if (!isCharging)
        {
            currentBattery -= dischargeRate * Time.deltaTime;
            currentBattery = Mathf.Max(currentBattery, 0f);
            transform.localScale = new Vector3(currentBattery, currentBattery, 1f);

            if (currentBattery <= 0f)
            {
                GameOver();
            }

            PlayerPrefs.SetFloat(BatteryKey, currentBattery);
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