using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// dash
public class Dash : MonoBehaviour
{
    // dash �ӵ�
    public float speed = 1.5f;

    // dash �Ǻ�
    bool isDash;

    // Controller
    public OVRInput.Controller controller;
    public OVRInput.Button dashBtn;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(OVRInput.GetDown(dashBtn, controller))
        {
            if(isDash == false)
            {
                isDash = true;
                
            }
        }
    }
}
