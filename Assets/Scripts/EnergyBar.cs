using UnityEngine;
using UnityEngine.UI;

public class EnergyBar : MonoBehaviour
{
    [Header("UI")]
    public Image m_Bar;

    [Header("Info")]
    public int m_CurrentValue = 100;
    public int m_MaxValue = 100;

    private void Start()
    {
        UpdateUI();
    }

    public void TakeDamage(int value)
    {
        m_CurrentValue = Clamp(m_CurrentValue - value);
        UpdateUI();
    }

    public void Heal(int value)
    {
        m_CurrentValue = Clamp(m_CurrentValue + value);
        UpdateUI();
    }

    private void UpdateUI()
    {
        m_Bar.fillAmount = Mathf.Clamp01(m_CurrentValue / (float)m_MaxValue);
    }

    private int Clamp(int value)
    {
        return (int)Mathf.Clamp(value, 0.0f, m_MaxValue);
    }
}
