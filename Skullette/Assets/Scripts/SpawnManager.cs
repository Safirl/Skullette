using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public movePlayer movePlayer;

    public GameObject[] obstaclePrefabs;
    public GameObject[] skyGround;

    private float startDelay = 0f;
    private float spawnInterval = 1f;
    private float timer;
    private float bonusTimer = 0f;
    private float noPlatformTime = 10f;
    public float noBonusTime = 20f;
    public float GroundDelay;
    public float groundTimer;
    public float groundPos = 7.79f;


    float posSpawner;


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnSequence", startDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
        if (movePlayer.isPlayerAlive)
        {
            timer += Time.deltaTime;
            bonusTimer += Time.deltaTime;
            SpawnGround();
        }
        else
        {
            timer = 0;
            bonusTimer = 0;
            groundTimer = 0;
        }
    }


    //Spawn une séquence d'obstacles
    void SpawnSequence()
    {
        if (movePlayer.isPlayerAlive == true) {
            int obstacleIndex = Random.Range(0, obstaclePrefabs.Length);


            //to spawn 
            if ((obstacleIndex == 1 || obstacleIndex == 2) && timer < noPlatformTime)
            {
                SpawnSequence();
            }
            else if ((obstacleIndex == 4 || obstacleIndex == 5) && bonusTimer < noBonusTime)
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
        if (obstacleIndex == 4 || obstacleIndex == 5)
        {
            bonusTimer = 0f;
        }
    }


    void SpawnGround()
    {
        GroundDelay = Random.Range(2f, 3f);
        groundTimer += Time.deltaTime;
        Vector3 spawnGroundPos = new Vector3(20, groundPos, 0);

        if (groundTimer > GroundDelay)
        {
            Instantiate(skyGround[0], spawnGroundPos, obstaclePrefabs[0].transform.rotation);
            groundTimer = 0f;
        }
    }
}
