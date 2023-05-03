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

    private float bottomAxePosition = -3f;
    private float middleAxePosition = 6.7f;

    [SerializeField] private Vector3 _rotation;
    [SerializeField] private float _speed; 

    // Start is called before the first frame update
    void Start()
    {
        isPlayerAlive = true; 
    }

    // Update is called once per frame
    void Update()
    {

        if (isPlayerAlive)
        {
            transform.Rotate(_rotation * _speed * Time.deltaTime);
        }

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
            if (GameManager.instance.axe == 1)
            {
                transform.position = new Vector3(transform.position.x, bottomAxePosition, transform.position.z);
            }
            else
            {
                transform.position = new Vector3(transform.position.x, middleAxePosition, transform.position.z);
            }
        }
    }
}
