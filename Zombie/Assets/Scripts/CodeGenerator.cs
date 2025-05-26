using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Code")]

public class CodeGenerator : ScriptableObject
{
    public string generatedCode1, generatedCode2;

    public void GenerateCodes()
    {
        generatedCode1 = Random.Range(1000, 10000).ToString();
        generatedCode2 = Random.Range(1000, 10000).ToString();

        Debug.Log("Generated Code1: " + generatedCode1);
        Debug.Log("Generated Code2: " + generatedCode2);
    }
}