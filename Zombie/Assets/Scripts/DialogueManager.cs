
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;
 
public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance;
 
    public TextMeshProUGUI dialogueArea;
 
    private Queue<DialogueLine> lines;
    
    public bool isDialogueActive = false;
 
    private float typingSpeed = 0.05f;
 
 
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
 
        lines = new Queue<DialogueLine>();
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

        EndDialogue();
    }

    void EndDialogue()
    {
        isDialogueActive = false;
        dialogueArea.text = "";
    }
}