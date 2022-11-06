using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayHighSoreInMenu : MonoBehaviour
{
    [SerializeField] private HighScoreController highScoreController = null;
    [SerializeField] private TMP_Text scoreText = null;

    // Start is called before the first frame update
    void Start()
    {
        highScoreController = GameObject.Find("HighScoreController").GetComponent<HighScoreController>();
        highScoreController.endGameRunning();
        scoreText.text = "Score: " + highScoreController.getHighScore();
    }
}
