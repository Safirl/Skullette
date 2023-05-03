using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movePlayer : MonoBehaviour
{

    public Rigidbody2D playerRigidBody;
    public float jumpStrenght;
    public bool isPlayerAlive = true;
    public bool isOnGround = true;
    public Vector3 PlayerPosition;
    public LogicScript logicScript;

    private float bottomAxesPosition = -3f;

    // Start is called before the first frame update
    void Start()
    {
        isPlayerAlive = true; 
    }

    // Update is called once per frame
    void Update()
    {

        PlayerPosition = transform.position;
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
            logicScript.Death();
        }

        else if (collision.collider.CompareTag("Ground")) {
            isOnGround = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Platform"))
        {
            transform.position = new Vector3(transform.position.x, bottomAxesPosition, transform.position.z);
        }
    }
}
