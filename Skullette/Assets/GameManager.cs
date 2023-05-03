using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public movePlayer movePlayer;

    public static GameManager instance = null;
    public float globalSpeed = 5f;
    public int axe = 1;

    private float skyPosition = 8.4f;
    private float groundPosition = -1f;

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
}
