using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Code : MonoBehaviour
{
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
        }
        else if (codeTextValue == "3184")
        {
            decrypted.safe2 = true;
            lockCanvas.SetActive(false);
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
