using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] obstaclePrefabs;
    public float startDelay = 0f;
    public float spawnInterval = 0f;
    public float tutorialTime;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObstacles", startDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
        tutorialTime += Time.deltaTime;
    }

    void SpawnObstacles()
    {
        int obstacleIndex = Random.Range(0, obstaclePrefabs.Length);


        //to spawn 
        if (obstacleIndex == 1 && tutorialTime < 15f)
        {
            SpawnObstacles();
        }


        else
        {
            Vector3 spawnPos = new Vector3(10, 0.5f, 0);
            Instantiate(obstaclePrefabs[obstacleIndex], spawnPos, obstaclePrefabs[obstacleIndex].transform.rotation);

                if (obstacleIndex == 1)
            {

                tutorialTime = 0f;
            }
        }
    }
}
