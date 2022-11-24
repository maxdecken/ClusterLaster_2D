using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighScoreController : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText = null;
    [SerializeField] private TMP_Text scoreBoosterActiveText = null;
    [SerializeField] private Transform playerPosition = null;
    [SerializeField] private int scoreDivisor = 5;
    [SerializeField] private float scoreBoostActiveSec = 15f;
    private int currentMulipyler = 1;
    private float currentMulipylerAddedTime = -1;
    private float latestPosition = 0;
    private float scoreValue = 0;
    private bool gameRunning = false;
    
    // Start is called before the first frame update
    void Start()
    {
        gameRunning = true;
        latestPosition = playerPosition.position.x;
        scoreText.text = "Score: " + ((int) scoreValue);
        scoreBoosterActiveText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //Handle the muliplyer and degrade over time
        if(gameRunning){
            if(currentMulipyler > 1){
                if(Time.time - currentMulipylerAddedTime >= scoreBoostActiveSec){
                    currentMulipyler --;
                    if(currentMulipyler > 1){
                        currentMulipylerAddedTime = Time.time;
                        scoreBoosterActiveText.text = "SCORE BOOST " + currentMulipyler + "x";
                    }else{
                        scoreBoosterActiveText.gameObject.SetActive(false);
                    }
                }
            }

            //Calc current Score
            if(playerPosition.position.x > latestPosition){
                float distance = playerPosition.position.x - latestPosition;
                latestPosition = playerPosition.position.x;
                scoreValue += (distance/scoreDivisor) * currentMulipyler;
                scoreText.text = "Score: " + ((int) scoreValue);
            }
        }
    }

    
    public void scoreBooster(){
        currentMulipyler ++;
        currentMulipylerAddedTime = Time.time;
        scoreBoosterActiveText.text = "SCORE BOOST " + currentMulipyler + "x"; 
        scoreBoosterActiveText.gameObject.SetActive(true);
    }

    public int getHighScore(){
        return (int) scoreValue;
    }

    public void endGameRunning(){
        gameRunning = false;

        //If no HighScoreFile exists, create a new one
        if(!PlayerPrefs.HasKey("highScore")){
            PlayerPrefs.SetInt("highScore", 0);
        }

        //If new HighScore, store locally
        if(PlayerPrefs.GetInt("highScore") < (int) scoreValue){
            PlayerPrefs.SetInt("highScore", (int) scoreValue);
        }
    }
}
