using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacle : MonoBehaviour
{

    public float moveSpeed;
    public float deadZone;
    public Rigidbody2D obstacleRigidBody;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        //Pour détruire les objets
        obstacleRigidBody.MovePosition(obstacleRigidBody.position + Vector2.left * moveSpeed * Time.deltaTime); 
        if (transform.position.x < deadZone)
        {
            Destroy(gameObject);
        }
    }
}
