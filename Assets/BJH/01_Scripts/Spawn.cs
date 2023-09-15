using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// �÷��̾ ������
// ���� ����Ʈ�� �÷��̾ �����Ѵ�.
// ���� Ư�� ��ġ�� Ʈ���Ÿ� ������
// ���� ����Ʈ�� �ش� ��ġ�� �����Ѵ�.
// ��� : �÷��̾� ���� ����, ���� ����Ʈ ������Ʈ����(Ʈ���Ÿ� ������), ���� ��ġ�� ������ �� ����, ȭ�� ��Ӱ� ���� UI
public class Spawn : MonoBehaviour
{
    bool playerState = true;

    public GameObject spawnPoint01;
    public GameObject spawnPoint02;
    public GameObject spawnPoint03;

    public GameObject ui;

    Transform savedSpawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        savedSpawnPoint = spawnPoint01.transform;
        ui.SetActive(false);

        img = ui.GetComponent<Image>();

    }

    // Update is called once per frame
    void Update()
    {
        if(playerState == false)
        {
            print("�÷��̾� ��ġ�� " + savedSpawnPoint.position + "�� �̵��߽��ϴ�.");
            PlayerMoveToSpawnPoint();
        }

        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            print("�÷��̾ �׾����ϴ�.");
            playerState = false;
        }
    }

    float currentTime = 0;
    Image img;
    void PlayerMoveToSpawnPoint()
    {

        currentTime += Time.deltaTime;

        // ȭ�� ��Ӱ� �����
        ui.SetActive(true);
        var temp = img.color;
        temp.a = 1f;


        if(currentTime >= 2)
        {
            ui.SetActive(false);
            transform.position = savedSpawnPoint.position;
            playerState = true;
            currentTime = 0;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        print("���� ����Ʈ�� " + other.gameObject.name + "�� ����Ǿ����ϴ�.");
        savedSpawnPoint.position = other.gameObject.transform.position;
    }
}
