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
    private int m_SentenceIndex;

    public void Update()
    {
        if (Input.anyKeyDown)
        {
            if (m_DialogPanel.Finished)
            {
                Next();
            }
            else
            {
                m_DialogPanel.FinishDialog();
            }
        }
    }

    private void CloneDialog(List<Dialog> dialogs)
    {
        m_Dialogs.Clear();
        foreach (var dialog in dialogs)
        {
            m_Dialogs.Add(dialog);
        }
    }

    public void Show(List<Dialog> dialogs)
    {
        CloneDialog(dialogs);
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

        NextDialog();
    }

    private void NextDialog()
    {
        m_CurrentDialog = m_Dialogs[0];
        if (m_CurrentDialog.type == DialogSentenceType.Random)
        {
            NextRandomDialog();
        }
        else
        {
            NextSequenceDialog();
        }
    }

    private void NextRandomDialog()
    {
        int count = m_CurrentDialog.sentences.Count;
        int index = Random.Range(0, count);
        m_DialogPanel.SetDialog(m_CurrentDialog, index);
        m_Dialogs.RemoveAt(0);
    }

    private void NextSequenceDialog()
    {
        m_DialogPanel.SetDialog(m_CurrentDialog, m_SentenceIndex);
        m_SentenceIndex++;
        if (m_SentenceIndex == m_CurrentDialog.sentences.Count)
        {
            m_SentenceIndex = 0;
            m_Dialogs.RemoveAt(0);
        }
    }
}
    