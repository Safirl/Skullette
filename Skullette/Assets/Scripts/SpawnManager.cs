using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public movePlayer movePlayer;

    public GameObject[] obstaclePrefabs;
    public float startDelay = 0f;
    public float spawnInterval = 0f;
    private float timer;
    public float noPlatformTime = 1f;

    float posSpawner;


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnSequence", startDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
    }


    //Spawn une séquence d'obstacles
    void SpawnSequence()
    {
        int obstacleIndex = Random.Range(0, obstaclePrefabs.Length);


        //to spawn 
        if ((obstacleIndex == 1 || obstacleIndex == 2) && timer < noPlatformTime)
        {
            SpawnSequence();
        }


        else
        {
            if (GameManager.instance.axe == 1)
            {
                posSpawner = 0.23f;
                InstantiateSequence(obstacleIndex, posSpawner);
                
            }

            if (GameManager.instance.axe == 2)
            {
                if (obstacleIndex == 1)
                {
                    SpawnSequence();
                }
                else
                {
                    posSpawner = 9.135f;
                    InstantiateSequence(obstacleIndex, posSpawner);
                }
            }

            if (GameManager.instance.axe == 0)
            {

                if (obstacleIndex == 2)
                {
                    SpawnSequence();
                }
                else
                {
                    posSpawner = -8.96f;
                    InstantiateSequence(obstacleIndex, posSpawner);
                }
            }
        }
    }

    //Génère une séquence en fonctione de l'axe
    void InstantiateSequence(int obstacleIndex, float posSpawner)
    {
        Vector3 spawnPos = new Vector3(20, posSpawner, 0);
        Instantiate(obstaclePrefabs[obstacleIndex], spawnPos, obstaclePrefabs[obstacleIndex].transform.rotation);

        if (obstacleIndex == 1 || obstacleIndex == 2)
        {
            timer = 0f;
        }
    }
}
