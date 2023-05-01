using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public movePlayer movePlayer;
    public float topPosition = 5.5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CameraUp();
    }

    void CameraUp()
    {
        if (movePlayer.PlayerPosition.y > topPosition) {
            Debug.Log("moving up!");
            transform.position = new Vector3(transform.position.x, 6.5f, transform.position.z);
        }
    }
}
