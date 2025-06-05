using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Gun : MonoBehaviour
{
    public DialogueTrigger empty, miss, kill;

    public GameObject crosshair;

    public AudioSource audio;

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
                StartCoroutine(WaitForDeath(hit));
            }
            else
            {
                miss.TriggerDialogue();
            }
        }
        else if (Input.GetKeyDown(KeyCode.Mouse1) && !PauseMenu.Instance.isPaused && ui.shellsCount <= 0)
        {
            empty.TriggerDialogue();
        }

        if (PauseMenu.Instance.isPaused)
        {
            crosshair.SetActive(false);
        }
        else
        {
            crosshair.SetActive(true);
        }

        if (SceneManager.GetActiveScene().name == "EndMenu")
        {
            Destroy(gameObject);
        }
    }

    public void Shoot()
    {
        audio.Play();

        ui.shellsCount -= 1;
        ui.shellsText.text = ui.shellsCount.ToString();
    }
    
    private IEnumerator WaitForDeath(RaycastHit2D hit)
    {
        zombie.animator.SetTrigger("Shot");
        zombie.hasBeenShot = true;

        yield return new WaitForSeconds(2f);

        Destroy(hit.collider.gameObject);
        kill.TriggerDialogue();
    }
}
