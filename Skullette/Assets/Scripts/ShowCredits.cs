using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowLore : MonoBehaviour
{
    public GameObject gameObject;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowBtn()
    {
        gameObject.SetActive(true);
    }


    public void CloseBtn()
    {
        gameObject.SetActive(false);
    }

}
