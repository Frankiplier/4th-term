using System.Collections;
using UnityEngine;

public class CameraFade : MonoBehaviour
{
    public static CameraFade Instance;

    public float speedScale;
    private bool fade = false;
    public bool isFading = false;

    public AnimationCurve Curve = new AnimationCurve(new Keyframe(0, 1),
    new Keyframe(0.5f, 0.5f, -1.5f, -1.5f), new Keyframe(1, 0));
    public Color fadeColor = Color.black;
    private float alpha = 1f, time = 0f;
    private Texture2D texture;
    private int direction = 0;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        alpha = 1f;
        time = 0f;
        direction = 1;

        texture = new Texture2D(1, 1);
        texture.SetPixel(0, 0, new Color(fadeColor.r, fadeColor.g, fadeColor.b, alpha));
        texture.Apply();
    }

    void Update()
    {
        if (fade)
        {
            if (direction == 0)
            {
                if (alpha >= 1f)
                {
                    alpha = 1f;
                    time = 0f;
                    direction = 1;

                    fade = false;
                    isFading = false;
                }

                else if (alpha == 0)
                {
                    alpha = 0f;
                    time = 1f;
                    direction = -1;

                    fade = false;
                    StartCoroutine(WaitBeforeFade());
                }
            }
        }
    }

    public void OnGUI()
    {
        if (alpha > 0f) GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), texture);

        if (direction != 0)
        {
            time += direction * Time.deltaTime * speedScale;
            alpha = Curve.Evaluate(time);
            texture.SetPixel(0, 0, new Color(fadeColor.r, fadeColor.g, fadeColor.b, alpha));
            texture.Apply();

            if (alpha <= 0f || alpha >= 1f) direction = 0;
        }
    }

    public void TriggerFade()
    {
        fade = true;
        isFading = true;

        direction = -1;
        time = 1f;
    }

    public bool IsFadingComplete()
    {
        return alpha <= 0f;
    }

    public bool IsFading()
    {
        return isFading;
    }

    private IEnumerator WaitBeforeFade()
    {
        yield return new WaitForSeconds(1.5f);

        isFading = false;
    }
}