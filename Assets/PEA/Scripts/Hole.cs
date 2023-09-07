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

    private void EnableCollider()
    {
        GetComponent<Collider>().enabled = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        //    if (collision.gameObject.CompareTag("Sphere"))
        //    {
        //        if (hasStone)
        //        {
        //            hasStone = false;

        //            //Destroy(spherePos.GetChild(0).gameObject);
        //        }
        //        else
        //        {
        //            hasStone = true;

        //            collision.transform.SetParent(spherePos);       
        //            collision.transform.position = spherePos.position;
        //            HoleManager.instance.CheckIsAnswer();
        //            //Mouse.instance.CreateSphere();
        //            //GetComponent<Collider>().enabled = false;
        //        }
        //    }
        //}

        if (collision.gameObject.CompareTag("Sphere") && !hasStone)
        {
            hasStone = true;
            collision.transform.SetParent(spherePos);
            collision.transform.position = spherePos.position;
        }
    }

    public void GetStone(GameObject stone)
    {
        hasStone = true;
        stone.transform.SetParent(spherePos);
        stone.transform.position = spherePos.position;
        HoleManager.instance.CheckIsAnswer();
    }

    private void OnCollisionExit(Collision collision)
    {
        if(hasStone && collision.transform.CompareTag("Sphere"))
        {
            hasStone = false;
            collision.transform.SetParent(null);
            HoleManager.instance.CheckIsAnswer();
        }
    }
}
