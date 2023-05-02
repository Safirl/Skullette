using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacle : MonoBehaviour
{

    public float deadZone;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + (Vector3.left * GameManager.instance.globalSpeed) * Time.deltaTime;

        //Pour détruire les objets
        if (transform.position.x < deadZone)
        {
            Destroy(gameObject);
        }

    }
}
