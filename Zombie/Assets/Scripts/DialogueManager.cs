
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
 
public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance;
 
    public TextMeshProUGUI dialogueArea;
    
    public bool isDialogueActive = false;
 
    private float typingSpeed = 0.03f;
 
    private void Update()
    {
        if (Instance == null)
            Instance = this;
    }
 
    public void StartDialogue(Dialogue dialogue)
    {
        if (dialogue.dialogueLines.Count == 0 || isDialogueActive == true)
        return;

        isDialogueActive = true;

        DialogueLine randomLine = dialogue.dialogueLines[Random.Range(0, dialogue.dialogueLines.Count)];

        StartCoroutine(TypeSentence(randomLine));
    }

    IEnumerator TypeSentence(DialogueLine dialogueLine)
    {
        dialogueArea.text = "";

        foreach (char letter in dialogueLine.line.ToCharArray())
        {
            dialogueArea.text += letter;

            yield return new WaitForSeconds(typingSpeed);
        }
        
        yield return new WaitForSeconds(1.5f);

        if (SceneManager.GetActiveScene().name == "EndMenu") DontEndDialogue();
        else EndDialogue();
    }

    void DontEndDialogue()
    {
        isDialogueActive = true;
    }

    void EndDialogue()
    {
        isDialogueActive = false;
        dialogueArea.text = "";
    }
}