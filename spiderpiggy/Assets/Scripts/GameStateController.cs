using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStateController : MonoBehaviour
{
    [SerializeField] private GameObject player = null;
    [SerializeField] private GameObject[] sceneComponentPrefab = null;
    [SerializeField] private GameObject sceneComponentBackgroundPrefab = null;
    [SerializeField] private int sceneElementWidth = 40;
    [SerializeField] private int sceneBackgroundElementWidth = 150;
    [SerializeField] private HighScoreController highScoreController = null;
    [SerializeField] private float maxEnemySpawnerScore = 100f;
    [SerializeField] private GameObject firstLevelElement = null;
    private float latestPositionAdded = 0;
    private float latestBackgroundPositionAdded = 0;
    private int lastComponentAdded = 0;
    // Start is called before the first frame update
    void Start()
    {
        latestPositionAdded = firstLevelElement.transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        //Add new SceneElement if needed (only working in the right movement direction)
        if(player.transform.position.x >= (latestPositionAdded-sceneBackgroundElementWidth/2)){
            
            float newPos = latestPositionAdded + sceneElementWidth;

            //random add new component
            int randomComponent = -1;
            do
            {
                randomComponent = Random.Range(0, sceneComponentPrefab.Length);
            }
            while(lastComponentAdded == randomComponent);

            GameObject newLevelComponent =  Instantiate(sceneComponentPrefab[randomComponent], new Vector2(newPos, 0), Quaternion.identity);

            //Deactivate Enemnys randomly, but driven by the current score
            foreach (Transform child in newLevelComponent.transform){
                if (child.tag == "Enemy"){
                    int currentHighScore = highScoreController.getHighScore();

                    //Up to the Score of 200, more and more enemny will randomly stay, if the score is higher than 200, all will stay
                    float randomEnemyActivation = Random.Range(0, maxEnemySpawnerScore);
                    if(randomEnemyActivation > currentHighScore){
                        child.gameObject.SetActive(false);
                    }
                }
            }

            latestPositionAdded = newPos;
            lastComponentAdded = randomComponent;
        }

        //Add new SceneBackgroundElement if needed (only working in the right movement direction)
        if(player.transform.position.x >= latestBackgroundPositionAdded){
            float newPos = latestBackgroundPositionAdded + sceneBackgroundElementWidth;

            Instantiate(sceneComponentBackgroundPrefab, new Vector2(newPos, 0), Quaternion.identity);

            latestBackgroundPositionAdded = newPos;
        }

        //Remove unused Elements afterwards
        foreach(GameObject sceneComponent in GameObject.FindGameObjectsWithTag("SceneComponent")){
            if(sceneComponent.transform.position.x <= player.transform.position.x - sceneElementWidth*2){
                Destroy(sceneComponent);
            }
        }

        //Remove unused BackgroundElements afterwards
        foreach(GameObject backgroundComponent in GameObject.FindGameObjectsWithTag("SceneComponentBackground")){
            if(backgroundComponent.transform.position.x <= player.transform.position.x - sceneBackgroundElementWidth- sceneBackgroundElementWidth/2){
                Destroy(backgroundComponent);
            }
        }

        //If the player has fallen out of the Game
        if(player.transform.position.y <= -40){
            SceneManager.LoadScene("GameOver");
        }
    }
}
