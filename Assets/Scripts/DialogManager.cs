using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    public static DialogManager Instance { get; private set; }

    public void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    public DialogHolder m_DialogPanel;
    private List<Dialog> m_Dialogs = new List<Dialog>();

    private Dialog m_CurrentDialog;

    public void Update()
    {
        if (Input.anyKeyDown)
        {
            Next();
        }
    }

    public void Show(List<Dialog> dialogs)
    {
        m_Dialogs = dialogs;
        m_DialogPanel.gameObject.SetActive(true);
        Bind();
    }

    public void Hide()
    {
        m_CurrentDialog = null;
        m_DialogPanel.gameObject.SetActive(false);
    }

    public void Next()
    {
        Bind();
    }

    public void Bind()
    {
        if (m_Dialogs.Count == 0)
        {
            Hide();
            return;
        }

        m_CurrentDialog = m_Dialogs[0];
        m_Dialogs.RemoveAt(0);
        m_DialogPanel.SetDialog(m_CurrentDialog);
    }
}
    