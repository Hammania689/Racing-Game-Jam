using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlignToPivot : MonoBehaviour
{
    public Transform pivot;
    Vector3 target;
    Vector3 movement;

    public float Speed = 2.2f;


    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        target = new Vector3(pivot.transform.position.x, pivot.transform.position.y, pivot.transform.position.z);

        transform.LookAt(target);

        if(Input.GetKey(KeyCode.RightArrow))
        {
            movement = Vector3.right;
            transform.position += movement * Speed * Time.fixedDeltaTime;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            movement = Vector3.left;
            transform.position += movement * Speed * Time.fixedDeltaTime;
        }
    }

}
