using UnityEngine;
using UnityEngine.SceneManagement;

public class GameoverManager : MonoBehaviour
{
    public static GameoverManager Instance { get; private set; }

    public bool m_UseChangeScene = true;
    public string m_SceneName = "Gameover";
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

    [ContextMenu("Gameover")]
    public void Show()
    {
        if (m_UseChangeScene)
        {
            SceneManager.LoadScene(m_SceneName);
        }
        else
        {
            m_Panel.SetActive(true);
        }
    }
}
