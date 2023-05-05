using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public movePlayer movePlayer;
    public Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "Score : " + movePlayer.scoreInt.ToString();
    }

    // Update is called once per frame
    void Update()
    {
       scoreText.text = "Score : " + movePlayer.scoreInt.ToString();
    }
}