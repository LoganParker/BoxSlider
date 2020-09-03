using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    public Transform[] spawnPoints; 
    public GameObject obstaclePrefab;
    private float timeToSpawn = 1.75f;
    public float timeBetweenWaves = 1f;
    // private void Start() {
    //     SpawnBlocks();
    // }

    void Update()
    {
        if(Time.time >= timeToSpawn)
        {
            SpawnBlocks();
            timeToSpawn = Time.time + timeBetweenWaves;
        }
    }
    void SpawnBlocks(){
        int randomIndex = Random.Range(0,spawnPoints.Length);
        for(int i = 0; i<spawnPoints.Length; i++)
        {
            if(randomIndex != i)
            {
                Instantiate(obstaclePrefab, spawnPoints[i].position, Quaternion.identity);
            }
        }

    }

}
