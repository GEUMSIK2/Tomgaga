using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ī�޶� ȸ��
public class PlayerRot : MonoBehaviour
{
    public float rotSpeed = 300f;

    // ȸ���� ����
    float mx = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float mouse_X = Input.GetAxis("Mouse X");

        // ȸ���� ������ ���콺 �Է°���ŭ �̸� ����
        mx += mouse_X * rotSpeed * Time.deltaTime;

        transform.eulerAngles = new Vector3(0, mx, 0);
    }
}
