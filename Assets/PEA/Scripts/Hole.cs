using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour
{
    private Transform spherePos;
    public bool isAnswer = false;                // Ȳ���ڸ��� �����ϴ� �������� �ƴ���
    public bool hasStone = false;                // ���� ���ִ��� �ƴ���

    void Start()
    {
        spherePos = transform.GetChild(0);
    }

    // ���ۿ��� ���� ������ �Լ�
    public void TakeStoneOut()
    {
        hasStone = false;
        Puzzle3.instance.CheckIsAnswer(isAnswer);
    }

    // ���� ���ۿ� �����ִ� �Լ�
    public void PutStone(GameObject stone)
    {
        hasStone = true;
        stone.transform.SetParent(spherePos);
        stone.transform.position = spherePos.position;
        Puzzle3.instance.CheckIsAnswer(isAnswer);
    }

    private void OnCollisionEnter(Collision collision)
    {
        //if (collision.gameObject.name.Contains("Stone") && !hasStone)
        //{
        //    hasStone = true;
        //    collision.transform.SetParent(spherePos);
        //    collision.transform.position = spherePos.position;
        //}
    }

    private void OnCollisionExit(Collision collision)
    {
        //if(hasStone && collision.gameObject.name.Contains("Stone"))
        //{
        //    hasStone = false;
        //    collision.transform.SetParent(null);
        //    Puzzle3.instance.CheckIsAnswer(isAnswer);
        //}
    }
}
