using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//���� ����Ʈ���� ���� ũ���� ���� ����� 
//�� �ȿ� �÷��̾ ������ 
//�ش��ϴ� ��ġ�� ���� ����Ʈ�� �����ϱ�
//(��, �ش��ϴ� ��ġ�� �ٴ� �Ʒ��� ������ �����Ƿ� Y���� ���Ƿ� ����)
public class SpawnPointTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        RaycastHit[] hits = Physics.SphereCastAll(transform.position, 10f, transform.forward, 0.001f);
    }
}
