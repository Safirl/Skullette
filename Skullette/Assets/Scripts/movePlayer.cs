using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movePlayer : MonoBehaviour
{

    public Rigidbody2D playerRigidBody;
    public float jumpStrenght;
    public bool isPlayerAlive = true;
    public bool isOnGround = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        //Permet au joueur de sauter
        if (Input.GetKeyDown(KeyCode.Space) == true && isOnGround == true)
        {
            playerRigidBody.velocity = Vector2.up * jumpStrenght;
            isOnGround = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        
        if (collision.collider.CompareTag("Obstacle")) {
            Debug.Log("You're dead");
            isPlayerAlive = false;
        }

        else if (collision.collider.CompareTag("Ground")) {
            isOnGround = true;
        }
    }
}
