using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveImage : MonoBehaviour
{
    public Vector3 m_Direction = Vector3.right;
    public float m_Speed = 0.1f;


    private void Update()
    {
        transform.Translate(m_Direction * m_Speed * Time.deltaTime);
        Debug.Log(transform.position);
        if (transform.position.x < -300)
            transform.position = new Vector3(200, transform.position.y, transform.position.z);
    }


}
