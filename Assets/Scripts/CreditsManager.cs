using UnityEngine;
using System.Text;
using TMPro;

public class CreditsManager : MonoBehaviour
{
    [Header("Setup")]
    public int m_CareerSize = 42;
    public int m_NameSize = 24;
    public int m_SpaceSize = 20;
    public float m_ScrollSpeed = 20.0f;
    public bool m_CapitalizeCareer;

    [Header("UI")]
    public TextMeshProUGUI m_TextUI;

    private Credits m_Credits;

    private void Start()
    {
        LoadCredits();
        BuildCredits();
    }

    public void LoadCredits()
    {
        var json = Resources.Load<TextAsset>("credits");
        m_Credits = JsonUtility.FromJson<Credits>(json.text);
    }

    public void BuildCredits()
    {
        var builder = new StringBuilder();
        foreach (var team in m_Credits.teams)
        {
            AddCareer(builder, team.career);
            AddNames(builder, team.names);
            AddSpace(builder);
        }

        m_TextUI.text = builder.ToString();
        Canvas.ForceUpdateCanvases();
    }

    private void AddCareer(StringBuilder builder, string career)
    {
        career = m_CapitalizeCareer ? career.ToUpper() : career;
        builder.Append($"<size={m_CareerSize}><b>{career}</b></size>");
        builder.AppendFormat($"<size={m_NameSize}>\n</size>");
    }

    private void AddNames(StringBuilder builder, string[] names)
    {
        foreach (var name in names)
        {
            builder.Append($"<size={m_NameSize}>{name}</size>");
            builder.AppendFormat($"<size={m_NameSize}>\n</size>");
        }
    }

    private void AddSpace(StringBuilder builder)
    {
        builder.AppendFormat($"<size={m_SpaceSize}>\n</size>");
    }

    public void Update()
    {
        m_TextUI.transform.Translate(Vector3.up * m_ScrollSpeed * Time.deltaTime);
    }
}

[System.Serializable]
public class Credits
{
    public CreditsTeam[] teams;
}

[System.Serializable]
public class CreditsTeam
{
    public string career;
    public string[] names;
}