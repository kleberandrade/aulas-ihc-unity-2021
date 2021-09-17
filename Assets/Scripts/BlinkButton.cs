using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlinkButton : MonoBehaviour
{
    public float m_Speed = 4.0f;
    private Image m_Image;

    private void Awake()
    {
        m_Image = GetComponent<Image>();
    }

    void Update()
    {
        float alpha = (1 + Mathf.Sin(Time.time * m_Speed)) * 0.5f;
        m_Image.color = new Color(1, 1, 1, alpha);
    }
}
