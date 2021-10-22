using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogEvent : MonoBehaviour
{
    public string m_TagEvent = "Player";
    public List<Dialog> m_Dialogs = new List<Dialog>();

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(m_TagEvent))
        {
            DialogManager.Instance.Show(m_Dialogs);
        }       
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(m_TagEvent))
        {
            DialogManager.Instance.Hide();
        }
    }
}
