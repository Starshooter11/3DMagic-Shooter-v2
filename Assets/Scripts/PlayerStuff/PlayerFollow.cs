using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollow : MonoBehaviour
{
    #region Editor Variables
    [SerializeField]
    private Transform m_playerTransform;

    [SerializeField]
    private Vector3 m_offset;

    [SerializeField]
    private float m_rotSpeed = 10;
    #endregion

    #region Main Updates

    private void LateUpdate()
    {
        Vector3 newPos = m_playerTransform.position + m_offset;

        transform.position = Vector3.Slerp(transform.position, newPos, 1);

        float rotAmt = m_rotSpeed * Input.GetAxis("Mouse X");
        transform.RotateAround(m_playerTransform.position, Vector3.up, rotAmt);

        m_offset = transform.position - m_playerTransform.position;
    }

    #endregion
}
