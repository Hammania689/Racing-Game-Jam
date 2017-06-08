using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road : MonoBehaviour
{
	BoxCollider2D box;
	Bounds targetCast;

    Vector3 spawnZone;
    Quaternion spawnRotation;

	// Use this for initialization
	void Awake()
	{
		box = gameObject.GetComponent<BoxCollider2D>();
		targetCast.extents = box.bounds.extents;
		targetCast.max = box.bounds.max;
		targetCast.min = box.bounds.min;
	}
	
	public Vector3 GetSpawnZone ()
	{
        return spawnZone;
	}

    public Quaternion GetSpawnRotation (Road subseqPeice)
    {
        if (subseqPeice.gameObject.tag == gameObject.tag)
            spawnRotation = Quaternion.Euler(0, 0, 180);
        else if (subseqPeice.gameObject.tag == "RoadStraight")
            spawnRotation = Quaternion.Euler(0, 0, 90);
        else
            spawnRotation = subseqPeice.transform.rotation;
        return spawnRotation;
    }

	private void OnDrawGizmos()
	{
        if (gameObject.tag == "RoadRight")
        {
            spawnZone = new Vector3(targetCast.max.x, transform.position.y);
            Debug.DrawLine(new Vector3(targetCast.max.x,transform.position.y), transform.position + (Vector3.right * 3), Color.cyan);
        }
        else if (gameObject.tag == "RoadLeft")
        {
            spawnZone = new Vector3(targetCast.min.x, transform.position.y);
            Debug.DrawLine(new Vector3(targetCast.min.x, transform.position.y), transform.position + (Vector3.left * 3), Color.yellow);
        }
        else
        {
            spawnZone = new Vector3(transform.position.x, targetCast.max.y);
            Debug.DrawLine(new Vector3(transform.position.x,targetCast.max.y), transform.position + (Vector3.up * 3), Color.red);
        }
    }
}
