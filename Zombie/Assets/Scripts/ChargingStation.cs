using UnityEngine;
using System.Collections;

public class ChargingStation : MonoBehaviour
{
    public float rechargeCooldown;
    private bool isCharging = false;
    private float currentCooldown = 0f;

    private Flashlight flashlight;

    void Start()
    {
        flashlight = GameObject.FindGameObjectWithTag("Flashlight").GetComponent<Flashlight>();
    }

    void Update()
    {
        if (currentCooldown > 0f)
        {
            currentCooldown -= Time.deltaTime;
        }
    }

    void OnMouseDown()
    {
        if (currentCooldown <= 0f && flashlight.currentBattery < flashlight.maxBattery)
        {
            StartCoroutine(ChargeFlashlight());
        }
    }

    private IEnumerator ChargeFlashlight()
    {
        isCharging = true;
        flashlight.isCharging = true;

        yield return new WaitForSeconds(1f);
        flashlight.RechargeBattery();

        currentCooldown = rechargeCooldown;

        isCharging = false;
        flashlight.isCharging = false;
    }
}