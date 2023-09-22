using Oculus.Interaction;
using System.Collections;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using UnityEngine;
using UnityEngine.UI;

// ���� ����Ʈ ���� ������ �÷��̾ �����Ǹ�
// �÷��̾ ���� ������ �� ���� ����Ʈ�� �÷��̾ ��ġ��Ų��.
public class Spawn : MonoBehaviour
{
    bool playerState;

    Transform savedSpawnPoint;
    
    // Start is called before the first frame update
    void Start()
    {
        playerState = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerState == false || Input.GetKeyDown(KeyCode.Q))
        {
            transform.position = savedSpawnPoint.position;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        print("���� ����Ʈ�� ���� ��ü : " + other.gameObject.name);
        string name = other.gameObject.name;
        
        if (name.Contains("Spawn"))
        {
            print("�÷��̾ Ʈ���ſ� ��ҽ��ϴ�.");
            savedSpawnPoint = other.gameObject.transform;
        }
    }
}