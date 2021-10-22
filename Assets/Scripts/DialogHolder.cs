using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogHolder : MonoBehaviour
{
    public Image m_AvatarUI;
    public TextMeshProUGUI m_NameUI;
    public TextMeshProUGUI m_SentenceUI;

    public void SetDialog(Dialog dialog, int index = 0)
    {
        m_AvatarUI.sprite = dialog.avatar;
        m_NameUI.text = dialog.name;
        m_SentenceUI.text = dialog.sentences[index];
    }
}