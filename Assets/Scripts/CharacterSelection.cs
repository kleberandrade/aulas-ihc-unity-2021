using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelection : MonoBehaviour
{
    public GameObject[] m_Characters;
    public bool m_CharacterRotate;
    public float m_RotateSpeed;
    private int m_CharacterIndex = 0;

    private void Start()
    {
        for (int i = 0; i < m_Characters.Length; i++)
            m_Characters[i].SetActive(i == m_CharacterIndex);
    }

    public void Select()
    {
        PlayerPrefs.SetInt("CharacterIndex", m_CharacterIndex);
        SceneManager.LoadScene("Gameplay");
    }

    public void Next()
    {
        m_Characters[m_CharacterIndex].SetActive(false);
        m_CharacterIndex = (m_CharacterIndex + 1) % m_Characters.Length;
        m_Characters[m_CharacterIndex].SetActive(true);
    }

    public void Previous()
    {
        m_Characters[m_CharacterIndex].SetActive(false);
        m_CharacterIndex--;
        if (m_CharacterIndex < 0)
            m_CharacterIndex = m_Characters.Length - 1;
        m_Characters[m_CharacterIndex].SetActive(true);
    }

    private void Update()
    {
        if (m_CharacterRotate)
            transform.Rotate(Vector3.up,m_RotateSpeed * Time.deltaTime);
    }
}
