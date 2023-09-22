using Oculus.Interaction;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using UnityEngine;
using UnityEngine.UI;

// ���� ����Ʈ ���� ������ �÷��̾ �����Ǹ�
// �÷��̾ ���� ������ �� ���� ����Ʈ�� �÷��̾ ��ġ��Ų��.
public class Spawn : MonoBehaviour
{
    public bool playerState;

    public Transform savedSpawnPoint;
    
    // Start is called before the first frame update
    void Start()
    {
        playerState = true;
        savedSpawnPoint = transform;
    }

    // Update is called once per frame
    void Update()
    {
        reSpawn();
    }

    private void reSpawn()
    {
        if (playerState == false || Input.GetKeyDown(KeyCode.Q))
        {
            transform.position = savedSpawnPoint.position;
            Debug.Log("�÷��̾ " + savedSpawnPoint + "�� �̵� ���׽��ϴ�.");
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