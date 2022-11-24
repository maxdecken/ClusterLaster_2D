using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayHighSoreInMenu : MonoBehaviour
{
    [SerializeField] private HighScoreController highScoreController = null;
    [SerializeField] private TMP_Text bestScoreEverText = null;
    [SerializeField] private TMP_Text scoreText = null;

    // Start is called before the first frame update
    void Start()
    {
        highScoreController = GameObject.Find("HighScoreController").GetComponent<HighScoreController>();
        highScoreController.endGameRunning();

        int currentHighScore = highScoreController.getHighScore();
        
        scoreText.text = "New Score: " + currentHighScore;

        //If a new highScore was set, or Score is the same as current highScore
        int bestScoreEver = PlayerPrefs.GetInt("highScore");
        if(bestScoreEver <= currentHighScore){
            bestScoreEverText.text = "New High-Score!!!";
        }else{
            bestScoreEverText.text = "Best Score Ever: " + bestScoreEver;
        }
    }

    void OnDestroy(){
        Destroy(highScoreController);
    }
}
