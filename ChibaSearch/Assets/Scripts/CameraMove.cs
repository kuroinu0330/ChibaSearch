using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    Transform m_Transform;
    private Camera m_Camera;
    // Start is called before the first frame update
    void Start()
    {
        m_Transform = this.gameObject.GetComponent<Transform>();
        m_Camera= this.gameObject.GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        //���N���b�N�Ŋg��
        if (Input.GetMouseButtonDown(0))
        {
            m_Camera.orthographicSize = m_Camera.orthographicSize - 2.0f;
        }
        //�E�N���b�N�ŏk��
        if (Input.GetMouseButtonDown(1))
        {
            m_Camera.orthographicSize = m_Camera.orthographicSize + 2.0f;
        }
    }
}
