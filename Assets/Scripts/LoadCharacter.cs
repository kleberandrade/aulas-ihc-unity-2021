using UnityEngine;

public class LoadCharacter : MonoBehaviour
{
    public GameObject[] m_Characters;
    public Transform m_SpawnPoint;

    private void Start()
    {
        var position = m_SpawnPoint.position;
        if (SaveManager.Instance.Load())
        {
            position = SaveManager.Instance.m_Data.respawnPoint;
        }


        Debug.Log($"Respawn Position: {position}");

        int index = PlayerPrefs.GetInt("CharacterIndex", 0);
        GameObject prefab = m_Characters[index];
        GameObject character = Instantiate(prefab,
            position,
            m_SpawnPoint.rotation
        );

        Player script = character.GetComponent<Player>();
        script.enabled = true;
    }
}
