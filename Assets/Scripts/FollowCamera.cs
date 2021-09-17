using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public float m_Height = 10.0f;
    private GameObject m_Target;

    private void Start()
    {
        InvokeRepeating("FindTarget", 0.0f, 1.0f);
    }

    private void FindTarget()
    {
        if (m_Target != null) return;
        m_Target = GameObject.FindGameObjectWithTag("Player");
    }

    private void LateUpdate()
    {
        if (m_Target == null) return;

        var position = m_Target.transform.position;
        position.y += m_Height;
        transform.position = position;
    }
}

