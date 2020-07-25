using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMove : MonoBehaviour
{
    [SerializeField]
    CollisionMove m_CollisionMove;
    [SerializeField]
    Vector3 m_MousePosition;
    [SerializeField]
    Vector3 m_Cursor;
    [SerializeField]
    Vector3 m_Cursor_Old;

    Transform m_Trans;
    CapsuleCollider2D m_Coll;


    // Start is called before the first frame update
    void Start()
    {
        m_Trans = GetComponent<Transform>();
        m_Coll = m_CollisionMove.GetComponent<CapsuleCollider2D>();
    }

    void Update()
    {
        m_Cursor_Old = m_Cursor;

        m_MousePosition = Input.mousePosition;
        m_Cursor = Camera.main.ScreenToWorldPoint(m_MousePosition);
        m_Cursor.z = 0.0f;

        //座標変更
        m_Trans.transform.position = m_Cursor;
        m_Coll.size = new Vector2(m_Coll.size.x, Mathf.Sqrt(Vector3.Dot(m_Cursor - m_Cursor_Old, m_Cursor - m_Cursor_Old)));
        m_CollisionMove.transform.position = (m_Cursor + m_Cursor_Old) * 0.5f;
        //角度調整
        Vector3 dir = Vector3.Normalize(m_Cursor - m_Cursor_Old);
        float angle = Mathf.Rad2Deg*Mathf.Acos(Vector3.Dot(dir, Vector3.up));
        m_CollisionMove.transform.rotation = Quaternion.AngleAxis(angle, Vector3.Cross(Vector3.up,dir));
    }
}
