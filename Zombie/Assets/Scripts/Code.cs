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

    public Animator anim;

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
            anim.SetTrigger("Good");
            codeTextValue = "";
            audio3.Play();

            StartCoroutine(WaitForSafe1Animation());
        }
        else if (gameObject.tag == "Safe2" && codeTextValue == generatedCode.generatedCode2)
        {
            audio1.Play();
            anim.SetTrigger("Good");
            codeTextValue = "";
            audio3.Play();

            StartCoroutine(WaitForSafe2Animation());
        }
        else if (codeTextValue.Length >= 4)
        {
            audio2.Play();
            anim.SetTrigger("Bad");
            codeTextValue = "";
            locked.TriggerDialogue();

            StartCoroutine(WaitForBadAnimation());
        }
    }

    public void AddDigit(string digit)
    {
        codeTextValue += digit;
    }

    private IEnumerator WaitForSafe1Animation()
    {
        yield return new WaitForSeconds(0.5f);

        anim.SetTrigger("Nothing");

        opened.TriggerDialogue();
        cam.allowMovement = true;
        decrypted.safe1 = true;
    }

    private IEnumerator WaitForSafe2Animation()
    {
        yield return new WaitForSeconds(0.5f);

        anim.SetTrigger("Nothing");

        opened.TriggerDialogue();
        cam.allowMovement = true;
        decrypted.safe2 = true;
    }

    private IEnumerator WaitForBadAnimation()
    {
        yield return new WaitForSeconds(1f);

        anim.SetTrigger("Nothing");
    }
}