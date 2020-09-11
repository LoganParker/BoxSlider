using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIBlockSpawner : MonoBehaviour
{
    public Transform[] spawnPoints; 
    public GameObject obstaclePrefab;
    public GameObject scorePrefab;
    public GameObject cube;
    private AIMovementScript controller;

    public float forwardForce;
    public float timeBetweenWaves = 1f;
    private List<GameObject> spawnedObjects = new List<GameObject>();
    
    
    private void Awake()
    {
         controller = GetComponentInChildren<AIMovementScript>();
         controller.OnReset += DestroyAllSpawnedObjects;
         
    }
    private void Start()
    {
        InvokeRepeating("SpawnBlocks",0f,timeBetweenWaves);
    }
    void FixedUpdate()
    {
        for (int i = 0; i < spawnedObjects.Count; i++)
        {
            // Add constant force to obstacle
            if (spawnedObjects[i])
            {
                spawnedObjects[i].GetComponent<Rigidbody>().AddForce(0, 0, -forwardForce * Time.fixedDeltaTime, ForceMode.VelocityChange);

                // Remove obstacle if past player
                if (spawnedObjects[i].transform.position.z < cube.transform.position.z-10)
                {
                    Destroy(spawnedObjects[i]);
                }

            }
        }
    }
    void SpawnBlocks(){
        int randomIndex = Random.Range(0,spawnPoints.Length);
        for(int i = 0; i<spawnPoints.Length; i++)
        {
            if(randomIndex != i)
            {
                var spawned = Instantiate(obstaclePrefab, spawnPoints[i].position, Quaternion.identity);
                spawnedObjects.Add(spawned);
            }else
            {
                var scoreBlock = Instantiate(scorePrefab, spawnPoints[i].position,Quaternion.identity);
                spawnedObjects.Add(scoreBlock); 
            }
        }
    }
    private void DestroyAllSpawnedObjects()
    {
        for(int i = spawnedObjects.Count -1; i >= 0; i--)
        {
            Destroy(spawnedObjects[i]);
            spawnedObjects.RemoveAt(i);
        }
    }
}
