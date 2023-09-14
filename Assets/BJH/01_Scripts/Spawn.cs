using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �÷��̾ ������
// ���� ����Ʈ�� �÷��̾ �����Ѵ�.
// ���� Ư�� ��ġ�� Ʈ���Ÿ� ������
// ���� ����Ʈ�� �ش� ��ġ�� �����Ѵ�.
// ��� : �÷��̾� ���� ����, ���� ����Ʈ ������Ʈ����(Ʈ���Ÿ� ������), ���� ��ġ�� ������ �� ����
public class Spawn : MonoBehaviour
{
    bool playerState = true;

    public GameObject spawnPoint01;
    public GameObject spawnPoint02;
    public GameObject spawnPoint03;

    Transform savedSpawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        savedSpawnPoint = spawnPoint01.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(playerState == false)
        {
            print("�÷��̾� ��ġ�� " + savedSpawnPoint.position + "�� �̵��߽��ϴ�.");
            transform.position = savedSpawnPoint.position;
            playerState = true;
        }

        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            print("�÷��̾ �׾����ϴ�.");
            playerState = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        print("���� ����Ʈ�� " + other.gameObject.name + "�� ����Ǿ����ϴ�.");
        savedSpawnPoint.position = other.gameObject.transform.position;
    }
}
