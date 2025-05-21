using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Code : MonoBehaviour
{
    public DialogueTrigger locked, opened;

    public GameObject lockCanvas;

    [SerializeField] TMP_Text codeText;
    string codeTextValue = "";
    public Containers decrypted;

    void Update()
    {
        codeText.text = codeTextValue;

        if (codeTextValue == "9205")
        {
            decrypted.safe1 = true;
            lockCanvas.SetActive(false);

            opened.TriggerDialogue();
        }
        else if (codeTextValue == "3184")
        {
            decrypted.safe2 = true;
            lockCanvas.SetActive(false);

            opened.TriggerDialogue();
        }

        if (codeTextValue.Length >= 4)
        {
            codeTextValue = "";

            locked.TriggerDialogue();
        }
    }

    public void AddDigit(string digit)
    {
        codeTextValue += digit;
    }
}
