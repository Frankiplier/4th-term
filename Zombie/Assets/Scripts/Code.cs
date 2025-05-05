using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Code : MonoBehaviour
{
    [SerializeField] TMP_Text codeText;
    string codeTextValue = "";
    public Containers decrypted;

    void Update()
    {
        codeText.text = codeTextValue;

        if (codeTextValue == "9205")
        {
            decrypted.codePanel = true;
        }

        if (codeTextValue.Length >= 4)
        {
            codeTextValue = "";
        }
    }

    public void AddDigit(string digit)
    {
        codeTextValue += digit;
    }
}
