using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public static SaveManager Instance { get; private set; }

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

    public string m_FileName = "game.save";
    public SaveData m_Data;

    private string SavePath => $"{Application.persistentDataPath}/{m_FileName}";

    [ContextMenu("Save")]
    public void Save()
    {
        using (var stream = new FileStream(SavePath, FileMode.Create))
        {
            using (var writer = new StreamWriter(stream))
            {
                var json = JsonUtility.ToJson(m_Data);
                var data = Encrypt(json);
                writer.Write(data);
            }
        }
    }

    private void SaveFile(object state)
    {
        using (var stream = File.Open(SavePath, FileMode.Create))
        {
            var formatter = new BinaryFormatter();
            formatter.Serialize(stream, state);
        }
    }

    private Dictionary<string, object> LoadFile()
    {
        if (!File.Exists(SavePath))
        {
            return new Dictionary<string, object>();
        }

        using (var stream = File.Open(SavePath, FileMode.Open))
        {
            var formatter = new BinaryFormatter();
            return (Dictionary<string, object>) formatter.Deserialize(stream);
        }
    }

    private void SaveState(Dictionary<string, object> state)
    {
        foreach (var saveable in FindObjectsOfType<SaveableEntity>())
        {
            state[saveable.Id] = saveable.CaptureState();
        }
    }

    private void LoadState(Dictionary<string, object> state)
    {
        foreach (var saveable in FindObjectsOfType<SaveableEntity>())
        {
            if (state.TryGetValue(saveable.Id, out object value))
            {
                saveable.RestoreState(value);
            }
        }
    }

    public string Encrypt(string data)
    {
        // TODO: criar algoritmo de criptografia
        return data;
    }

    [ContextMenu("Load")]
    public bool Load()
    {
        if (!File.Exists(SavePath)) return false;
        using (var reader = new StreamReader(SavePath))
        {
            var data = reader.ReadToEnd();
            var json = Decrypt(data);
            JsonUtility.FromJsonOverwrite(json, m_Data);
        }
        return true;
    }

    public string Decrypt(string data)
    {
        // TODO: criar algoritmo de descriptografia
        return data;
    }

    public void Delete()
    {
        if (!File.Exists(SavePath)) return;
        File.Delete(SavePath);
    }

    // TODO: Código para teste das funcionalidades
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L)) Delete();
    }
}


[System.Serializable]
public class SaveData
{
    public Vector3 respawnPoint;
}
