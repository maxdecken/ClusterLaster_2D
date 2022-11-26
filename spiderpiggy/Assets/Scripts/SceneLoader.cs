using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private string sceneName = string.Empty;
    public void LoadScene(){
        //Destroy old HighScoreControllers, if a new Game starts
        if(sceneName == "MainGame"){
            Destroy(GameObject.Find("HighScoreController"));
        }
        SceneManager.LoadScene(sceneName);
    }
}
