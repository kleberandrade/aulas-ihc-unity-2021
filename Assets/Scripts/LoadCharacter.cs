using UnityEngine;

public class LoadCharacter : MonoBehaviour
{
    public GameObject[] m_Characters;
    public Transform m_SpawnPoint;

    private void Start()
    {
        int index = PlayerPrefs.GetInt("CharacterIndex", 0);
        GameObject prefab = m_Characters[index];
        GameObject character = Instantiate(prefab,
            m_SpawnPoint.position,
            m_SpawnPoint.rotation
        );

        Player script = character.GetComponent<Player>();
        script.enabled = true;
    }
}
