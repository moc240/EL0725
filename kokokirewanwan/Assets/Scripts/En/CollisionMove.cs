using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionMove : MonoBehaviour
{
    [SerializeField]
    GameObject m_Sprite;

    CapsuleCollider2D m_Coll;
    bool m_IsSlash = false;

    // Start is called before the first frame update
    void Start()
    {
        m_Coll = GetComponent<CapsuleCollider2D>();


    }

    // Update is called once per frame
    void Update()
    {
        m_IsSlash = Input.GetMouseButton(0);
        m_Coll.enabled = m_IsSlash;

        m_Sprite.transform.localScale = new Vector3(1, m_IsSlash?m_Coll.size.y/0.2f:0, 1);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        //仮処理
        if (col.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Slash");
        }
    }
}
