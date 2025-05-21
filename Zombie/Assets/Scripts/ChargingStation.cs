using UnityEngine;
using System.Collections;

public class ChargingStation : MonoBehaviour
{
    public DialogueTrigger trigger;

    public float rechargeCooldown;
    private bool isCharging = false;
    private float currentCooldown = 0f;

    private Flashlight flashlight;

    void Update()
    {
        if (flashlight == null)
        {
            flashlight = GameObject.FindGameObjectWithTag("Flashlight")?.GetComponent<Flashlight>();
        }

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
        if (flashlight == null) yield break;

        isCharging = true;
        flashlight.isCharging = true;

        yield return new WaitForSeconds(1f);

        flashlight.RechargeBattery();

        trigger.TriggerDialogue();

        currentCooldown = rechargeCooldown;

        isCharging = false;
        flashlight.isCharging = false;
    }
}