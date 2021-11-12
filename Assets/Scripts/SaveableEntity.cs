using System;
using UnityEngine;

public class SaveableEntity : MonoBehaviour
{

    public string Id { get; private set; }

    [ContextMenu("Generate Id")]
    private void GeneratedId() => Id = Guid.NewGuid().ToString();

    public object CaptureState()
    {
        return null;
    }

    public void RestoreState(object state)
    {

    }

}
