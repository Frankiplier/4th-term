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

    void Start()
    {
        codeTextValue = "";
    }

    void Update()
    {
        codeText.text = codeTextValue;

        if (gameObject.tag == "Safe1" && codeTextValue == generatedCode.generatedCode1)
        {
            decrypted.safe1 = true;
            codeTextValue = "";
            opened.TriggerDialogue();
        }

        if (gameObject.tag == "Safe2" && codeTextValue == generatedCode.generatedCode2)
        {
            decrypted.safe2 = true;
            codeTextValue = "";
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