using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacle : MonoBehaviour
{

    private float deadZone = -16;
    public Rigidbody2D MyRigidbody2D;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MyRigidbody2D.MovePosition(MyRigidbody2D.position + Vector2.left * GameManager.instance.globalSpeed * Time.fixedDeltaTime);
        //transform.position = transform.position + (Vector3.left * GameManager.instance.globalSpeed) * Time.deltaTime;

        //Pour détruire les objets
        if (transform.position.x < deadZone)
        {
            Destroy(gameObject);
        }

    }
}
