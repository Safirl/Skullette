using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGround : MonoBehaviour
{
    float groundTimer = 0f;
    public GameObject[] Ground;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MakeSpawnGround();
    }

    void MakeSpawnGround()
    {
        float groundDelay = 2f;
        
        groundTimer += Time.deltaTime;
        Debug.Log(groundTimer);
        float groundPos = -1.96f;
        float bottomGroundPos = -11.11f;


        Vector3 spawnGroundPos = new Vector3(20, groundPos, 1);
        Vector3 spawnBottomGroundPos = new Vector3(20f, bottomGroundPos, 1);


        if (groundTimer > groundDelay)
        {
            Instantiate(Ground[0], spawnGroundPos, Ground[0].transform.rotation);
            Instantiate(Ground[0], spawnBottomGroundPos, Ground[0].transform.rotation);

            groundTimer = 0f;
        }
    }
}
