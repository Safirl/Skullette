using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraController : MonoBehaviour
{

    public movePlayer movePlayer;

    //limite de la position du joueur


    //Position de la caméra
    private float topAxesPosition = 12f;
    private float middleAxesPosition = 3.6f;
    private float bottomAxesPosition = -5.3f;
    public float cameraSpeed = 1f;
    public float transitionTime = 1f;




    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(transform.position.x, middleAxesPosition, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        MoveCamera();
    }

    void MoveCamera()
    {

        if (GameManager.instance.axe == 1)
        {

            DOTween.To(() => transform.position, y => transform.position = y, new Vector3(transform.position.x, middleAxesPosition, transform.position.z), transitionTime);

        }

        if (GameManager.instance.axe == 2) {
            DOTween.To(() => transform.position, y => transform.position = y, new Vector3(transform.position.x, topAxesPosition, transform.position.z), transitionTime);

        }

        if (GameManager.instance.axe == 0)
        {
            DOTween.To(() => transform.position, y => transform.position = y, new Vector3(transform.position.x, bottomAxesPosition, transform.position.z), transitionTime);

        }
    }
}
