using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour
{
    private Transform spherePos;
    public bool isAnswer = false;                // Ȳ���ڸ��� �����ϴ� �������� �ƴ���
    public bool hasStone = false;                 // ���� ���ִ��� �ƴ���

    void Start()
    {
        spherePos = transform.GetChild(0);
    }

    void Update()
    {
        
    }

    public void GetStone(GameObject stone)
    {
        hasStone = true;
        stone.transform.SetParent(spherePos);
        stone.transform.position = spherePos.position;
        HoleManager.instance.CheckIsAnswer();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.Contains("Stone") && !hasStone)
        {
            hasStone = true;
            collision.transform.SetParent(spherePos);
            collision.transform.position = spherePos.position;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if(hasStone && collision.gameObject.name.Contains("Stone"))
        {
            hasStone = false;
            collision.transform.SetParent(null);
            HoleManager.instance.CheckIsAnswer();
        }
    }
}
