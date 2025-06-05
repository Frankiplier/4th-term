using UnityEngine;
using System.Collections;

public class ChargingStation : MonoBehaviour
{
    public DialogueTrigger trigger;

    public float rechargeCooldown;
    private bool isCharging = false;
    private float currentCooldown = 0f;

    private Flashlight flashlight;

    public AudioSource audio1, audio2;

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
            audio1.Play();

            StartCoroutine(ChargeFlashlight());
        }
    }

    private IEnumerator ChargeFlashlight()
    {
        if (flashlight == null) yield break;

        isCharging = true;
        flashlight.isCharging = true;

        yield return new WaitForSeconds(3f);

        flashlight.RechargeBattery();

        trigger.TriggerDialogue();

        currentCooldown = rechargeCooldown;


        audio1.Stop();
        audio2.Play();

        isCharging = false;
        flashlight.isCharging = false;
    }
}