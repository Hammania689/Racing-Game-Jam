using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawBounds : MonoBehaviour {

    BoxCollider2D box;
    Bounds targetCast;
   
	// Use this for initialization
	void Start ()
    {
        box = gameObject.GetComponent<BoxCollider2D>();
        targetCast.extents = box.bounds.extents;
        targetCast.max = box.bounds.max;
        targetCast.min = box.bounds.min;
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void OnDrawGizmos()
    {
        Debug.DrawLine(new Vector3 (targetCast.max.x,0), Vector3.left,Color.red);
    }
}
