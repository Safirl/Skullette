using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public movePlayer movePlayer;

    //limite de la position du joueur
    private float skyPosition = 8.4f;
    private float groundPosition = -1f;

    public int axe = 1;


    //Position de la caméra
    private float topAxesPosition = 12f;
    private float middleAxesPosition = 3.6f;
    private float bottomAxesPosition = -5f;
    public float cameraSpeed = 1f;




    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(transform.position.x, middleAxesPosition, transform.position.z);
        axe = 1;
    }

    // Update is called once per frame
    void Update()
    {
        MoveCamera();
    }

    void MoveCamera()
    {
        if (movePlayer.PlayerPosition.y < skyPosition && movePlayer.PlayerPosition.y > groundPosition)
        {
            axe = 1;
            if (transform.position.y > middleAxesPosition)
            {
                transform.Translate(Vector3.down * cameraSpeed * Time.deltaTime);
            }
            if (transform.position.y < middleAxesPosition)
            {
                transform.Translate(Vector3.up * cameraSpeed * Time.deltaTime);
            }
        }

        if (movePlayer.PlayerPosition.y > skyPosition) {
            axe = 2;
            transform.position = new Vector3(transform.position.x, topAxesPosition, transform.position.z);
        }

        if (movePlayer.PlayerPosition.y < groundPosition)
        {
            axe = 0;
            transform.position = new Vector3(transform.position.x, bottomAxesPosition, transform.position.z);
        }
    }
}
