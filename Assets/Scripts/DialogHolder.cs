using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogHolder : MonoBehaviour
{
    public Image m_AvatarUI;
    public TextMeshProUGUI m_NameUI;
    public TextMeshProUGUI m_SentenceUI;
    [Range(0.0f, 1.0f)]
    public float m_LetterTime = 0.01f;
    [Range(0, 5)]
    public int m_FixedLetterStep = 1;
    [Range(2.0f, 10.0f)]
    public float m_MultiplyLetterStep = 3.0f;
    public DialogFinishType m_Type = DialogFinishType.Finish;

    private int m_LetterStep;
    private string m_Sentence;
    private int m_Index;
    private float m_ElapsedTime;

    public bool Finished => m_Index == m_Sentence.Length;

    public void FinishDialog()
    {
        if (m_Type == DialogFinishType.Finish)
        {
            m_Index = m_Sentence.Length - 1;
            NextLetter();
        }
        else
        {
            m_LetterStep = (int)(m_FixedLetterStep * m_MultiplyLetterStep);
        }
    }

    public void SetDialog(Dialog dialog, int index = 0)
    {
        m_AvatarUI.sprite = dialog.avatar;
        m_NameUI.text = dialog.name;

        m_Sentence = dialog.sentences[index];
        m_SentenceUI.text = string.Empty;
        m_Index = 0;
        m_LetterStep = m_FixedLetterStep;
    }

    public void NextLetter()
    {
        m_SentenceUI.text = m_Sentence.Substring(0, m_Index);
        m_Index += m_LetterStep;
        if (m_Index > m_Sentence.Length - 1)
        {
            m_Index = m_Sentence.Length - 1;
        }
    }

    public void Update()
    {
        if (Finished) return;

        m_ElapsedTime += Time.deltaTime;
        if (m_ElapsedTime < m_LetterTime) return;

        NextLetter();

        m_ElapsedTime = 0.0f;
    }
}

public enum DialogFinishType
{
    Finish,
    Speed,
}