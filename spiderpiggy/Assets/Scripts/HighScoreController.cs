using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighScoreController : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText = null;
    [SerializeField] private Transform playerPosition = null;
    [SerializeField] private int scoreDivisor = 5;
    private float highestXValue = 0;
    private bool gameRunning = false;
    
    // Start is called before the first frame update
    void Start()
    {
        gameRunning = true;
        scoreText.text = "Score: " + ((int) (playerPosition.position.x / scoreDivisor));
    }

    // Update is called once per frame
    void Update()
    {
        if(gameRunning && playerPosition.position.x > highestXValue){
            highestXValue = playerPosition.position.x;
            scoreText.text = "Score: " + ((int) (highestXValue / scoreDivisor));
        }
    }

    public int getHighScore(){
        return (int) (highestXValue / scoreDivisor);
    }

    public void endGameRunning(){
        gameRunning = false;
    }
}
