using System.Collections;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using UnityEngine;
using UnityEngine.UI;

// ���� ����Ʈ ���� ������ �÷��̾ �����Ǹ�
// �÷��̾ ���� ������ �� ���� ����Ʈ�� �÷��̾ ��ġ��Ų��.
public class Spawn : MonoBehaviour
{
    public GameObject player;
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
            player.transform.position = savedSpawnPoint.position;
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        print("���� ����Ʈ�� ���� ��ü : " + collision.gameObject.name);
        if(collision.gameObject.name.CompareTo("Player") == 0)
        {
            savedSpawnPoint.position = transform.position;
        }
    }
}