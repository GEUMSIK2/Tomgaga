using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �÷��̾ ��������
// �����ϴ� ���� ���� ȿ���� �ִ´�.
// ��� : �÷��̾� ���������� ����, �÷��̾� ��ġ, ��ƼŬ ȿ��
public class PlayerFall : MonoBehaviour
{
    public GameObject dust;
    public ParticleSystem ps;
    bool psStatus = false;

    bool isPlayerFall = false;

    // Start is called before the first frame update
    void Start()
    {
        if(psStatus == false)
        {
            ps.Stop();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        string collisionGo = collision.gameObject.name;
        if(collisionGo == "FallingGround")
        {
            isPlayerFall = true;

            // �÷��̾� ��ġ��
            dust.transform.position = transform.position;

            // ��ƼŬ ȿ���� ����
            ps.Play();
        }

        isPlayerFall = false;
    }
}
