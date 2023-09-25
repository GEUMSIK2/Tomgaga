using System;
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

    public Spawn spawn;

    bool isDash;

    // Controller
    public OVRInput.Controller lController;
    public OVRInput.Controller RController;
    public OVRInput.Button dashBtn;
    public OVRInput.Axis2D moveStick;

    // Start is called before the first frame update
    void Start()
    {
        speed = walkSpeed;
        rd = GetComponent<Rigidbody>();
        isDash = false;

        dashAudio.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        // �÷��̾� ���Ƿ� ���̱�
        if(Input.GetKeyDown(KeyCode.B))
        {
            Debug.Log("�÷��̾ �׿����ϴ�.");
            spawn.playerState = false;
        }

        // �̵��� ��������
        Vector2 axix = OVRInput.Get(moveStick, lController);

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

        if (OVRInput.Get(dashBtn, RController) && !isDash)
        {
            Debug.Log("dash ��ư�� �������ϴ�.");
            Dash();
        }

        else if(OVRInput.GetUp(dashBtn, RController) && isDash)
        {
            EndDash();
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




    // dash
    Rigidbody rd;
    public float dashSpeed = 10f;

    private void Dash()
    {
        //rd.AddForce(transform.forward * dashSpeed, ForceMode.Impulse);
        isDash = true;
        speed = dashSpeed;
        dashAudio.enabled = true;
        dashAudio.loop = true;
        //StartCoroutine(CoDash());
    }

    private void EndDash()
    {
        isDash = false;
        speed = walkSpeed;
        dashAudio.enabled = false;
        dashAudio.loop = false;

    }



    public float dashTime;
    //IEnumerator CoDash()
    //{
    //    dashAudio.enabled = true;
    //    dashAudio.loop = true;
    //    yield return new WaitForSeconds(dashTime);
    //    isDash = false;
    //    dashAudio.enabled = false;
    //    dashAudio.loop = false;
    //}
}

