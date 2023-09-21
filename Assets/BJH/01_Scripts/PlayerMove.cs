using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �÷��̾� �̵�
// �÷��̾� ������Ʈ, �Է� Ű, �̵� �ӵ�, ����
public class PlayerMove : MonoBehaviour
{
    // �ӵ�
    public float speed;
    public float walkSpeed = 0.5f;

    // ī�޶�
    public GameObject rig;

    // �����̴� ����
    bool isMoving;

    // audio
    public AudioSource walkAudio;
    public AudioSource dashAudio;


    // dash
    // dash �ӵ�
    public float dashSpeed = 1.5f;

    // dash �Ǻ�
    bool isDash;

    // Controller
    public OVRInput.Controller controller;
    public OVRInput.Button dashBtn;
    public OVRInput.Axis2D moveStick;

    // Start is called before the first frame update
    void Start()
    {
        speed = walkSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        // �̵��� ��������
        Vector2 axix = OVRInput.Get(moveStick, controller);

        // Vector2�� reference�� �ƴ϶� value����. �׷��� vector2.zero�� �ؾߵ�!!
        if(axix != Vector2.zero && isMoving == false) // �ȿ����̴ٰ� �����̰� ���� ��
        {
            walkAudio.Play();
            walkAudio.loop = true;
            isMoving = true;
        }
        else if(axix == Vector2.zero)
        {
            walkAudio.loop = false;
            isMoving = false;
        }

        if (OVRInput.Get(dashBtn, controller))
        {
            print("dash ��ư�� �������ϴ�.");
            if (isDash == false)
            {
                isDash = true;
                speed = dashSpeed;
                dashAudio.Play();
                dashAudio.loop = true;
            }
        }
        else
        {
            isDash = false;
            speed = walkSpeed;
            dashAudio.loop = false;


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

