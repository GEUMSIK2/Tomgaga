using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ������ �߻��ϸ�
// ī�޶� ��鸮�� ȿ���� �ְ�ʹ�.
public class CamShake : MonoBehaviour
{
    // ���� ���� �ð�
    public float shakeTime = 0.5f;

    // ���� ����
    public float shakePower = 0.3f;

    // ī�޶� �⺻ ��ġ
    Vector3 originPosition;

    // Start is called before the first frame update
    void Start()
    {
        originPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.J))
        {
            print("ī�޶� ��鸳�ϴ�.");
            StartCoroutine(ShakeCamera(shakePower, shakeTime));
        }
    }

    float timer = 0;
    IEnumerator ShakeCamera(float shakePower, float shakeTime)
    {
        while (timer <= shakeTime)
        {
            print("ī�޶� ��鸮�� �� : " + timer);
            transform.position = Random.insideUnitSphere * shakePower + originPosition;
            timer += Time.deltaTime;
            yield return null;
        }
        transform.position = originPosition;
        timer = 0;
    }
}
