using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �÷��̾��� ���� ���
// ��ư�� ������ �ݰ��� ����
// �ش��ϴ� �ݰ濡 ���� �� �ִ� ������Ʈ�� �ִٸ� []�� ���
// �ش� ������Ʈ�� �� ��ġ�� �̵�(�����尡 �ִٸ� Ű�׸�ƽ�� true)

// �÷��̾��� ���� ����
// �� ���� ��������
public class Grab : MonoBehaviour
{
    // ��� ����
    bool isGrab = false;

    // ����ִ� ������Ʈ ����
    GameObject grabGo;

    // �� ��¦ ��
    public GameObject getGoPosition;

    // ���ƹ��� ������Ʈ���� ��� empty gameobject
    public GameObject putDown;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch) || Input.GetKeyDown(KeyCode.Alpha1))
        {
            if(isGrab == false)
            {
                print("��� ��ư�� �������ϴ�.");

                Collider[] cols = Physics.OverlapSphere(transform.position, 0.5f);

                for (int i = 0; i < cols.Length; i++)
                {
                    print("������ �ݶ��̴�" + cols[i] + "������ �ݶ��̴��� ���ӿ�����Ʈ �±� : " + cols[i].gameObject.tag);

                    // ���� ���� collider�� tag�� targets��� 
                    if (cols[i].gameObject.CompareTag("Target"))
                    {
                        print("Target Tag�� ���� ���ӿ�����Ʈ�� �����Խ��ϴ�.");
                        cols[i].GetComponent<Rigidbody>().isKinematic = true;
                        cols[i].transform.parent = getGoPosition.transform;
                        cols[i].transform.localPosition = Vector3.zero;
                        grabGo = cols[i].gameObject;
                        isGrab = true;
                    }
                }
            }
            else
            {
                print("���� ��ư�� �������ϴ�.");
                grabGo.transform.parent = putDown.transform;
                grabGo.GetComponent<Rigidbody>().isKinematic = false;
                //grabGo.transform.position = transform.forward * 3f;
                isGrab = false;
                
            }

        }
    }

}
