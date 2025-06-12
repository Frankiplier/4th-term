using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class EndMenu : MonoBehaviour
{
    [SerializeField] Containers containers;
    public TypewriterEffect typewriterEffect;

    void Start()
    {
        MusicManager.Instance.PlayMusic("MainMenu");
        
        StartCoroutine(TriggerDialogueWithDelay());
    }

    private IEnumerator TriggerDialogueWithDelay()
    {
        yield return new WaitForSeconds(1f);

        if (containers.keys && containers.dish)
        {
            typewriterEffect.StartTyping("With the car keys you found in the safe, you were able to quickly escape from the zombie-infested hotel. The food you found in the restaurant helped you survive the long and exhausting journey. You have finally reached the safety of the survivors' camp. You are safe.");
        }
        else if (containers.keys)
        {
            typewriterEffect.StartTyping("Thanks to the car keys you found in the safe, you've managed to get to safety from the zombie-infested hotel. Unfortunately, when you stopped at a petrol station on the way to buy something to eat, you were attacked by a zombie petrol station attendant. You got bitten.");
        }
        else if (containers.dish)
        {
            typewriterEffect.StartTyping("The food you found in the restaurant energised you, but the long walk left you incredibly tired. You decided to sit down on a bench to rest for a moment and didn't notice the zombie approaching you from behind. You were bitten.");
        }
        else
        {
            typewriterEffect.StartTyping("You found nothing in the hotel that could help you survive your escape. Without energy or transport, a swarm of zombies quickly caught up with you. You were eaten.");
        }
    }

    public void MainMenu()
    {
        StartCoroutine(FadeBeforeTransition(0));
    }

    public void ExitGame()
    {
        StartCoroutine(FadeBeforeTransition(-1));
    }

    private IEnumerator FadeBeforeTransition(int sceneIndex)
    {
        CameraFade.Instance.TriggerFade();

        while (CameraFade.Instance.IsFading())
        {
            yield return null;
        }

        if (sceneIndex >= 0)
        {
            SceneManager.LoadScene(sceneIndex);
        }

        else
        {
            Application.Quit();
        }
    }
}
