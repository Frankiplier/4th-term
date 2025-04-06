using UnityEngine;
using UnityEngine.SceneManagement;

public class Flashlight : MonoBehaviour
{
    public float maxBattery, currentBattery, dischargeRate;
    public bool isCharging = false;

    void Start()
    {
        currentBattery = maxBattery;
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
        }
    }

    public void RechargeBattery()
    {
        currentBattery = maxBattery;
        isCharging = false;
    }

    void GameOver()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}