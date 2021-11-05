using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialog
{
    public string name;
    public Sprite avatar;
    public DialogSentenceType type = DialogSentenceType.Sequence;
    public List<string> sentences;
}

public enum DialogSentenceType
{
    Sequence,
    Random
}
