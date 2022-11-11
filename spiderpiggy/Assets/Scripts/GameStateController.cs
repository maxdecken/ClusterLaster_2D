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
    private int latestPositionAdded = 0;
    private int latestBackgroundPositionAdded = 0;
    private int lastComponentAdded = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Add new SceneElement if needed (only working in the right movement direction)
        if(player.transform.position.x >= latestPositionAdded){
            int newPos = latestPositionAdded + sceneElementWidth;

            //random add new component
            int randomComponent = -1;
            do
            {
                randomComponent = Random.Range(0, sceneComponentPrefab.Length);
            }
            while(lastComponentAdded == randomComponent);

            Instantiate(sceneComponentPrefab[randomComponent], new Vector2(newPos, 0), Quaternion.identity);

            latestPositionAdded = newPos;
            lastComponentAdded = randomComponent;
        }

        //Add new SceneBackgroundElement if needed (only working in the right movement direction)
        if(player.transform.position.x >= latestBackgroundPositionAdded){
            int newPos = latestBackgroundPositionAdded + sceneBackgroundElementWidth;

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
            SceneManager.LoadScene("MaxTestGameOver");
        }
    }
}
