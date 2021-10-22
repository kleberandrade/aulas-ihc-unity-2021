using UnityEngine;

public class HintText : MonoBehaviour
{
    public static HintText Instance { get; private set; }
    public GameObject m_Panel;

    public void Awake()
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
        Hide();
    }

    public void Show()
    {
        m_Panel.SetActive(true);
    }

    public void Hide()
    {
        m_Panel.SetActive(false);
    }
}
