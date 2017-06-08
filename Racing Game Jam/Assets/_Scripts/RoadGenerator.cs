using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadGenerator : MonoBehaviour
{
    public GameObject[] road = new GameObject[2];
    public int count = 4;

    int randomPeice;
    Quaternion spawnRot;
    Road spawningPeice, prevPeice;
    Vector3 spawnPos;

    Dictionary<int, Road> currRoad = new Dictionary<int,Road>();

    private void Awake()
    {
    }
    // Use this for initialization
    void Start ()
    {
        spawnPos = new Vector3(0,0,1);

        for (int i = 0; i < count; i++)
        {
            randomPeice = Mathf.RoundToInt(Random.Range(0, 3));
            spawningPeice = road[randomPeice].GetComponent<Road>();


            currRoad.Add(i, spawningPeice);

            Instantiate(road[randomPeice] as GameObject, spawnPos, spawnRot, this.gameObject.transform);

            currRoad[i] = spawningPeice;
            //spawnRot = spawningPeice.GetSpawnRotation(prevPeice);
            spawnPos = spawningPeice.GetSpawnZone() + spawningPeice.transform.position;
           // Debug.Log((i+1) + " position is : " + spawnPos);
        }
        Debug.Log(currRoad.Values);
        Debug.Log(currRoad.ContainsKey(1));
    }
}
