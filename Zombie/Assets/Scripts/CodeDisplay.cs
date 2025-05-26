using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class CodeDisplay : MonoBehaviour
{
    [SerializeField] CodeGenerator generatedCode;
    public TMP_Text generatedCodeDisplay;

    void Start()
    {
        Debug.Log("generatedCodeDisplay is " + (generatedCodeDisplay == null ? "NULL" : "NOT NULL"));
        
        if (SceneManager.GetActiveScene().name == "HotelRoom")
        {
            generatedCodeDisplay.text = "Code: " + generatedCode.generatedCode1;
        }
        
        if (SceneManager.GetActiveScene().name == "Stairway")
        {
            generatedCodeDisplay.text = "Code: " + generatedCode.generatedCode2;
        }
    }
}
