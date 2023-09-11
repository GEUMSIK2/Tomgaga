using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ī�޶� ȸ��
// ��� : ī�޶�, ȸ�� �ӵ�
public class CameraRot : MonoBehaviour
{
    // ȸ�� �ӵ�
    public float rotSpeed = 200f;

    float mx = 0;
    float my = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // ���콺�� �Է� �ޱ�(�¿�)
        float Mouse_X = Input.GetAxis("Mouse X");
        float Mouse_Y = Input.GetAxis("Mouse Y");

        // ȸ���� ������ ���콺 �Է� ����ŭ �̸� ����
        mx += Mouse_X * rotSpeed * Time.deltaTime;
        my += Mouse_Y * rotSpeed * Time.deltaTime;

        my = Mathf.Clamp(my, -90f, 90);

        transform.eulerAngles = new Vector3(-my, mx, 0);
    }
}
