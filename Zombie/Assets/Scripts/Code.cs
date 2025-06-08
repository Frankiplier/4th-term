using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Code : MonoBehaviour
{
    [SerializeField] CodeGenerator generatedCode;
    public DialogueTrigger locked, opened;

    [SerializeField] TMP_Text codeText;
    string codeTextValue = "";
    public Containers decrypted;

    public AudioSource audio1, audio2, audio3;
    public CameraController cam;

    void Start()
    {
        codeTextValue = "";
    }

    void Update()
    {
        codeText.text = codeTextValue;

        if (gameObject.tag == "Safe1" && codeTextValue == generatedCode.generatedCode1)
        {
            audio1.Play();

            decrypted.safe1 = true;
            codeTextValue = "";
            opened.TriggerDialogue();

            audio3.Play();
            cam.allowMovement = true;
        }

        if (gameObject.tag == "Safe2" && codeTextValue == generatedCode.generatedCode2)
        {
            audio1.Play();

            decrypted.safe2 = true;
            codeTextValue = "";
            opened.TriggerDialogue();

            audio3.Play();
            cam.allowMovement = true;
        }

        if (codeTextValue.Length >= 4)
        {
            audio2.Play();
            cam.allowMovement = true;

            codeTextValue = "";
            locked.TriggerDialogue();
        }
    }

    public void AddDigit(string digit)
    {
        codeTextValue += digit;
    }
}