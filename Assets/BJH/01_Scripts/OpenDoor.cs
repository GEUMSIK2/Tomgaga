using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �ڵ��� ���� ���� �̻� ������
// ���� ������ �Լ��� ���

// �ڵ��� ���� ���� ���Ϸ� ������
// �ڵ� ���󺹱�
public class OpenDoor : MonoBehaviour
{
    // �ڵ�
    public GameObject handle;


    public void Update()
    {
        // �ڵ��� ��� �Ʒ��� ������
        if(OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch))
        {
            // Ŭ�� ���ڸ��� �������� �����
            //
            //handle.transform.rotation = Quaternion.Euler(new Vector3(0, 0, z));

            // ������ �������� ���?
            // rotation -50 ~ -100
            float z = transform.rotation.z;

        }
    }
}
