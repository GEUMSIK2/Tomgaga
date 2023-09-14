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
    private float prevY = 0;

    // ��� ����
    bool isGrab = false;

    // ����ִ� ������Ʈ ����
    GameObject grabGo;

    // �� ��¦ ��
    public GameObject getGoPosition;

    // ���ƹ��� ������Ʈ���� ��� empty gameobject
    public GameObject putDown;

    // �κ����� ������ ���� ĭ �ϳ��ϳ�
    private Slot slot;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch) || Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (isGrab == false)
                return;

            Collider[] cols = Physics.OverlapSphere(transform.position, 0.5f);

            if (slot != null)
            {
                print("���Կ��� ������ ������");
                grabGo = slot.TakeItemOut(transform);
            }

            // �ƴϸ� ���� ������ �ִ� ������ ����
            else
            {
                print("������ �ִ� ������ ���");
                grabGo = CompareDistance(cols);
            }

            grabGo.GetComponent<Rigidbody>().isKinematic = true;
            grabGo.transform.parent = getGoPosition.transform;
            grabGo.transform.localPosition = Vector3.zero;
            isGrab = true;
        }

        if (OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch))
        {
            print("111111111");
            Collider[] cols = Physics.OverlapSphere(transform.position, 0.5f);
            for (int i = 0; i < cols.Length; i++)
            {
                if (cols[i].gameObject.CompareTag("Handle"))
                {
                    print("handle");
                    if (prevY == 0)
                    {
                        prevY = transform.position.y;
                    }

                    Handle handle = cols[i].transform.parent.GetComponent<Handle>();

                    handle.HoldHandle(prevY - transform.position.y);
                    prevY = transform.position.y;
                }
            }
        }

        if (OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch))
        {
            //print("���� ��ư�� �������ϴ�.");
            if(slot != null && grabGo != null)
            {
                print(slot.name);
                slot.GetItem(grabGo);
                grabGo = null;
                isGrab = false;
            }
            else if(grabGo != null)
            {
                grabGo.transform.parent = null;
                grabGo.GetComponent<Rigidbody>().isKinematic = false;
                isGrab = false;
            }

            prevY = 0;

        }
    }

    // �Ÿ� ��
    private GameObject CompareDistance(Collider[] cols)
    {
        Collider nearest = null;
        float nearestDistance = float.MaxValue;

        foreach (Collider collider in cols)
        {
            if (!collider.CompareTag("Target"))
                continue;

            float distance = Vector3.Distance(transform.position, collider.transform.position);
            if (distance < nearestDistance)
            {
                nearest = collider;
                nearestDistance = distance;                
            }
        }

        return nearest.gameObject;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Slot"))
        {
            slot = other.GetComponent<Slot>();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(slot != null && other.gameObject == slot.gameObject)
        {
            slot = null;
        }
    }
}
