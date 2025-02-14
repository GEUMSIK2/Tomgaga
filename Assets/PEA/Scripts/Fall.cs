using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fall : MonoBehaviour
{
    private Vector3 originPos;
    private Transform fallLoad;
    private ParticleSystem dust;

    public bool isFall = false;

    private void Start()
    {
        //dust = GetComponentInChildren<ParticleSystem>();
        //dust.transform.SetAsLastSibling();
        //fallLoad = transform.GetChild(0);
        fallLoad = transform;
        originPos = fallLoad.position;
    }

    void Update()
    {
        if(isFall && fallLoad.localPosition.y > -0.4f)
        {
            //fallLoad.Translate(Vector3.down * 3f * Time.deltaTime);
            fallLoad.position += Vector3.down * 3f * Time.deltaTime;
        }
    }

    public void StartFall()
    {
        isFall = true;
        //dust.Play();
    }

    public void ResetPos()
    {
        isFall = false;
        fallLoad.position = originPos;
    }
}
