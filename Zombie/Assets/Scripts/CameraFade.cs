using System.Collections;
using UnityEngine;

public class CameraFade : MonoBehaviour
{
    public static CameraFade Instance;

    public float fadeDuration = 1f;
    public Color fadeColor = Color.black;

    private float alpha = 1f;
    private Texture2D texture;
    private bool isFading = false;
    private Coroutine fadeCoroutine;

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
        texture = new Texture2D(1, 1);
        texture.SetPixel(0, 0, fadeColor);
        texture.Apply();

        alpha = 1f;
        isFading = true;
        StartCoroutine(FadeIn());
    }

    void OnGUI()
    {
        if (alpha > 0f)
        {
            Color color = new Color(fadeColor.r, fadeColor.g, fadeColor.b, alpha);
            GUI.color = color;
            GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), texture);
        }
    }

    public void StartFadeIn(float duration = -1f)
    {
        if (fadeCoroutine != null) StopCoroutine(fadeCoroutine);
        fadeCoroutine = StartCoroutine(FadeIn(duration > 0f ? duration : fadeDuration));
    }

    public void StartFadeOut(float duration = -1f)
    {
        if (fadeCoroutine != null) StopCoroutine(fadeCoroutine);
        fadeCoroutine = StartCoroutine(FadeOut(duration > 0f ? duration : fadeDuration));
    }

    public bool IsFading()
    {
        return isFading;
    }

    private IEnumerator FadeIn(float duration = 1f)
    {
        isFading = true;
        float time = 0f;
        alpha = 1f;

        while (time < duration)
        {
            time += Time.unscaledDeltaTime;
            alpha = Mathf.Lerp(1f, 0f, time / duration);
            yield return null;
        }

        alpha = 0f;
        isFading = false;
    }

    private IEnumerator FadeOut(float duration = 1f)
    {
        isFading = true;
        float time = 0f;
        alpha = 0f;

        while (time < duration)
        {
            time += Time.unscaledDeltaTime;
            alpha = Mathf.Lerp(0f, 1f, time / duration);
            yield return null;
        }

        alpha = 1f;
        isFading = false;
    }
}