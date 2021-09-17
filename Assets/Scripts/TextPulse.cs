using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextPulse : MonoBehaviour
{
    public List<string> m_Texts;
    public float m_Speed = 4.0f;
    public float m_Range = 0.2f;

    public TextMeshProUGUI m_TextUI;

    private void Awake()
    {
        m_TextUI = GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        int index = Random.Range(0, m_Texts.Count);
        m_TextUI.text = m_Texts[index];   
    }

    private void Update()
    {
        float scale = (1 + Mathf.Sin(Time.time * m_Speed)) * 0.5f;
        transform.localScale = Vector3.one + Vector3.one * scale * m_Range; 
    }
}
