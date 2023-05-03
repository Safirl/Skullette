using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public movePlayer movePlayer;

    public static GameManager instance = null;
    public float globalSpeed = 1f;
    public int axe = 1;

    private float skyPosition = 8.4f;
    private float groundPosition = -1f;
    public float timer;
    public float increaseSpeed = 5f; 


    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        } else

        {
            Destroy(this);
        }
    }

    // Update is called once per frame
    void Update()
    {
        playerPosition();
        speedAcceleration();
    }

    void playerPosition ()
    {
        if (movePlayer.PlayerPosition.y < skyPosition && movePlayer.PlayerPosition.y > groundPosition)
        {
            axe = 1;
        }

        if (movePlayer.PlayerPosition.y > skyPosition)
        {
            axe = 2;
        }

        if (movePlayer.PlayerPosition.y < groundPosition)
        {
            axe = 0;
        }
    }

    void speedAcceleration()
    {
        timer += Time.deltaTime;
        if (timer >= increaseSpeed)
        {
            globalSpeed += 1;
            timer = 0;
        }
    }
}
