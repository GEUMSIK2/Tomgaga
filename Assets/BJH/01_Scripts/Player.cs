using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool playerState;
    public Vector3 savedSpawnPoint;
    public PlayerDie playerDie;
    void Start()
    {
        playerDie = GetComponent<PlayerDie>();
        playerState = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(playerState == false) // ���� �÷��̾� ���°� ������ �ȴٸ�?
        {
            playerDie.Die(); // �÷��̾� ���� Ui �� ����� ����� ����
        }   
    }
}
