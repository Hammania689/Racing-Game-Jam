using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    public float Speed = 2.2f;

    float time = 0;
    Rigidbody rb;
    Quaternion currentRot;

    Vector3 movement;
    Vector3 curve;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        movement = Vector3.up;
        curve = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        float x = Mathf.Cos(time);
        float y = Mathf.Sin(time);
        float z = 0f;

        Debug.DrawRay(transform.localPosition,Vector3.up + curve,Color.green);

        if(Input.GetKey(KeyCode.RightArrow))
        {
            curve = new Vector3(x, y, z);
            time += Time.deltaTime;
            transform.rotation = Quaternion.Euler(0,0,Mathf.Acos(time) * 180);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            curve = new Vector3(x, y, z);
            time += Time.deltaTime;
            transform.rotation = Quaternion.Euler(0, 0, -Mathf.Acos(time) * 180);
        }
        else if(transform.rotation == Quaternion.identity)
        {
            time = 0;
        }

        rb.velocity =  transform.rotation * movement * Speed;
    }
}
