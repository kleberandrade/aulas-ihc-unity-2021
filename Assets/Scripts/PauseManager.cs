using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    public static PauseManager Instance { get; private set; }
    public bool m_IsPaused { get; set; }
    public string m_QuitSceneName = "Menu";

    public GameObject m_Panel;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    public void Start()
    {
        Button resumeButton = m_Panel.transform.GetChild(1).GetChild(3).GetComponent<Button>();
        resumeButton.onClick.AddListener(() => Hide());

        Button quitButton = m_Panel.transform.GetChild(1).GetChild(4).GetComponent<Button>();
        quitButton.onClick.AddListener(() => {
            Hide();
            SceneManager.LoadScene(m_QuitSceneName);
        });

        m_Panel.SetActive(false);
    }

    public void Show()
    {
        m_Panel.SetActive(true);
        Time.timeScale = 0.0f;
        m_IsPaused = true;
    }

    public void Hide()
    {
        m_Panel.SetActive(false);
        Time.timeScale = 1.0f;
        m_IsPaused = false;
    }

    public void ChangePauseStatus()
    {
        if (m_IsPaused)
        {
            Hide();
        }
        else
        {
            Show();
        }
    }

    public void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            ChangePauseStatus();
        }
    }
}
