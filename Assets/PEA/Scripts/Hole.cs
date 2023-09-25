using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour
{
    //private Transform spherePos;
    private GameObject stone;
    public bool isAnswer = false;                // Ȳ���ڸ��� �����ϴ� �������� �ƴ���
    public bool hasStone = false;                // ���� ���ִ��� �ƴ���

    void Start()
    {
        //spherePos = transform.GetChild(0);
    }

    // ���ۿ��� ���� ������ �Լ�
    public GameObject TakeStoneOut()
    {
        if (hasStone)
        {
            hasStone = false;
            Puzzle3.instance.CheckIsAnswer(isAnswer);
            return stone;
        }

        return null;
    }

    // ���� ���ۿ� �����ִ� �Լ�
    public void PutStone(GameObject stone)
    {
        hasStone = true;
        stone.transform.SetParent(transform);
        stone.transform.localPosition = Vector3.zero;
        stone.GetComponent<Rigidbody>().useGravity = false;
        this.stone = stone;
        Puzzle3.instance.CheckIsAnswer(isAnswer);
    }
}
