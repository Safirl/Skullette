using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MoveBackground : MonoBehaviour
{
    private float deadZone = -16.1f;
    public Rigidbody2D MyRigidbody2D;
    private float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update()
    {
        spawnBackground();
        speed = (GameManager.instance.globalSpeed) / 2;
        MyRigidbody2D.MovePosition(MyRigidbody2D.position + Vector2.left * speed * Time.fixedDeltaTime);
        //transform.position = transform.position + (Vector3.left * GameManager.instance.globalSpeed) * Time.deltaTime;

        //Pour détruire les objets
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }

    void spawnBackground()
    {
        float middlePos = 1.76f;
        float startPos = 19.62f;
        float y = 1.91f;

        Vector3 backgroundStartPos = new Vector3(startPos, y, 1f);


        if (transform.position.x <= deadZone)
        {
            transform.position = backgroundStartPos;
        }
    }
}
