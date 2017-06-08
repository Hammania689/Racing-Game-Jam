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

    Dictionary<int, Road> currRoad = new Dictionary<int, Road>();

    // Use this for initialization
    void Start ()
    {
        spawnPos = new Vector3(0,0,1);

        for (int i = 0; i < count; i++)
        {
            // Selects any 1 of the 3 possible peices
            randomPeice = Mathf.RoundToInt(Random.Range(0, 3));

            // Sets the random number to the correlating array index prefab
            spawningPeice = road[randomPeice].GetComponent<Road>();

            // Adds the current peice to the Dictionary
            currRoad.Add(i, spawningPeice);

            // Spawns the Current peice
            if(i >= 1)
            {
                // Stores previous dictionary element in variable
                prevPeice = currRoad[i - 1];
                spawnRot = prevPeice.GetSpawnRotation(prevPeice);
                spawnPos = prevPeice.GetSpawnZone();
            }

            // Spawns the road accordingly
            Instantiate(road[randomPeice] as GameObject, spawnPos, spawnRot, this.gameObject.transform);

            //currRoad[i] = spawningPeice;
            spawnPos = spawningPeice.GetSpawnZone() + spawningPeice.transform.position;

        }
    }
}
