using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �÷��̾� ȸ��
public class PlayerRot : MonoBehaviour
{
    public float rotSpeed = 200f;

    // ȸ���� ����
    float mx = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float moust_X = Input.GetAxis("Mouse X");

        mx += moust_X * rotSpeed * Time.deltaTime;

        transform.eulerAngles = new Vector3(0, mx, 0);
    }
}
