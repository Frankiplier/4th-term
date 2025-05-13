using UnityEngine;
using UnityEngine.SceneManagement;

public class Gun : MonoBehaviour
{
    public GameObject crosshair;

    public static Gun Instance;
    private Interface ui;
    private Zombie zombie;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }

        else
        {
            Instance = this;

            if (SceneManager.GetActiveScene().name != "MainMenu")
            {
                DontDestroyOnLoad(gameObject);
            }

            else
            {
                Destroy(gameObject);
            }
        }
    }

    void Start()
    {
        crosshair.SetActive(true);
    }

    void Update()
    {
        if (ui == null)
        {
            ui = GameObject.FindGameObjectWithTag("Interface")?.GetComponent<Interface>();
        }

        if (zombie == null)
        {
            zombie = GameObject.FindGameObjectWithTag("Zombie")?.GetComponent<Zombie>();
        }

        if (Input.GetKeyDown(KeyCode.Mouse1) && !PauseMenu.Instance.isPaused && ui.shellsCount >= 1)
        {
            Shoot();

            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

            if (hit.collider != null && hit.collider.CompareTag("Zombie"))
            {
                Destroy(hit.collider.gameObject);
            }
        }

        if (PauseMenu.Instance.isPaused)
        {
            crosshair.SetActive(false);
        }
        else
        {
            crosshair.SetActive(true);
        }
    }

    public void Shoot()
    {
        ui.shellsCount -= 1;
        ui.shellsText.text = ui.shellsCount.ToString();
    }
}
