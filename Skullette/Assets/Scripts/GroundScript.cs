using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundScript : MonoBehaviour
{

    public Rigidbody2D myRigidBody;
    private float deadZone = -16;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        myRigidBody.MovePosition(myRigidBody.position + Vector2.left * GameManager.instance.groundSpeed * Time.fixedDeltaTime);
        if (transform.position.x < deadZone)
        {
            Destroy(gameObject);
        }
    }
}
