using System.Collections;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using UnityEngine;
using UnityEngine.UI;

// ���� ����Ʈ ���� ������ �÷��̾ �����Ǹ�
// �÷��̾ ���� ������ �� ���� ����Ʈ�� �÷��̾ ��ġ��Ų��.
public class Spawn : MonoBehaviour
{
    bool playerState = true;
    Transform savedSpawn;

    public GameObject spawnPoint;
    public GameObject Player;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Collider[] cols = Physics.OverlapSphere(transform.position, 20f);

        for (int i = 0; i < cols.Length; i++)
        {
            if (cols[i].name == "Player")
            {
                savedSpawn = spawnPoint.transform;
                
            }
        }

        if(playerState == false || Input.GetKeyDown(KeyCode.Q)) // �÷��̾ ����
        {
            Player.transform.position = savedSpawn.position;
        }
    }
}