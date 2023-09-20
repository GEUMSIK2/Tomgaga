using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �÷��̾� �̵�
// �÷��̾� ������Ʈ, �Է� Ű, �̵� �ӵ�, ����
public class PlayerMove : MonoBehaviour
{
    // �ӵ�
    public float speed = 3f;

    // ī�޶�
    public GameObject rig;

    // �����̴� ����
    bool isMoving;

    // �����
    AudioSource audio;

    // 

    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        // �̵��� ��������
        Vector2 axix = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick, OVRInput.Controller.LTouch);

        // Vector2�� reference�� �ƴ϶� value����. �׷��� vector2.zero�� �ؾߵ�!!
        if(axix != Vector2.zero && isMoving == false) // �ȿ����̴ٰ� �����̰� ���� ��
        {
            audio.Play();
            audio.loop = true;
            isMoving = true;
        }
        else if(axix == Vector2.zero)
        {
            audio.loop = false;
            isMoving = false;
        }


        // ���� �����ϱ�
        Vector3 dir = new Vector3(axix.x, 0, axix.y);

        // �����ǥ
        dir = rig.transform.TransformDirection(dir);

        dir = dir.normalized;



        // �̵��ϱ�
        transform.position += dir * speed * Time.deltaTime;



        // �׽�Ʈ ���ϰ� �ϰ�; Ű���� ���� �־����ϴ�.
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 k_dir = new Vector3(h, 0, v);

        k_dir = rig.transform.TransformDirection(k_dir);

        transform.position += k_dir * speed * Time.deltaTime;



    }

}

