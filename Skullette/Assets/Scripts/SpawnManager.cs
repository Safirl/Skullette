using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public movePlayer movePlayer;

    public GameObject[] obstaclePrefabs;
    public GameObject[] Ground;
    public GameObject background;

    private float startDelay = 0f;
    private float spawnInterval = 1f;
    private float platformTimer;
    public float timer;
    public float spawnTimer = 5f;
    private float bonusTimer = 0f;
    private float noPlatformTime = 10f;
    public float noBonusTime = 20f;
    public float skyGroundDelay;
    public float skyGroundTimer;
    public float skyGroundPos = 7.79f;

    public int obstacleIndex = 0;



    float posSpawner;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (movePlayer.isPlayerAlive)
        {
            platformTimer += Time.deltaTime;
            bonusTimer += Time.deltaTime;
            timer += Time.deltaTime;


            SpawnSkyGround();
            

            if (timer > spawnTimer)
            {
                SpawnSequence();
                spawnTimer = Random.Range(1f, 1.4f);
                timer = 0f;
            }
        }
        else
        {
            timer = 0;
            platformTimer = 0;
            bonusTimer = 0;
            skyGroundTimer = 0;
        }
    }


    //Spawn une séquence d'obstacles
    void SpawnSequence()
    {

        if (movePlayer.isPlayerAlive == true) {
            obstacleIndex = Random.Range(0, obstaclePrefabs.Length);

           

            //UnrepeatObstacles();


            //to spawn 
            if ((obstacleIndex == 1 || obstacleIndex == 2) && platformTimer < noPlatformTime)
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

                }

                if (GameManager.instance.axe == 2)
                {
                    if (obstacleIndex == 0)
                    {
                        obstacleIndex = 3;
                    }
                    if (obstacleIndex == 1)
                    {
                        SpawnSequence();
                    }
                    else
                    {
                        posSpawner = 9.135f;
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

                    }
                }
                InstantiateSequence(obstacleIndex, posSpawner);
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
            platformTimer = 0f;
        }
        if (obstacleIndex == 4 || obstacleIndex == 5)
        {
            bonusTimer = 0f;
        }
    }


    void SpawnSkyGround()
    {
        skyGroundDelay = Random.Range(2f, 3f);
        skyGroundTimer += Time.deltaTime;
        Vector3 spawnSkyGroundPos = new Vector3(20, skyGroundPos, 0);


        if (skyGroundTimer > skyGroundDelay)
        {
            Instantiate(Ground[0], spawnSkyGroundPos, Ground[0].transform.rotation);

            skyGroundTimer = 0f;
        }
    }

    

    

    //void UnrepeatObstacles()
    //{
    //    int numberOfBirds = 0;
    //    int numberOfgraves = 0;
    //    if (obstacleIndex == 3)
    //    {
    //        numberOfBirds += 1;
    //    }
    //    else if (obstacleIndex == 0)
    //    {
    //        numberOfgraves += 1;
    //    }

    //    if (numberOfBirds == 3)
    //    {
    //        obstacleIndex = 0;
    //    }
    //    else if (numberOfgraves == 3){
    //        obstacleIndex = 3;
    //    }
    //}
}
