using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStateController : MonoBehaviour
{
    [SerializeField] private GameObject player = null;
    [SerializeField] private GameObject sceneComponentPrefab = null;
    [SerializeField] private int sceneElementWidth = 40;
    private int latestPositionAdded = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Add new SceneElement if needed (only working in the right movement direction)
        if(player.transform.position.x >= latestPositionAdded + (sceneElementWidth/4)){
            int newPos = latestPositionAdded + sceneElementWidth;
            Instantiate(sceneComponentPrefab, new Vector2(newPos, 0), Quaternion.identity);
            latestPositionAdded = newPos;
        }

        //Remove unused Elements afterwards
        foreach(GameObject sceneComponent in GameObject.FindGameObjectsWithTag("SceneComponent")){
            if(sceneComponent.transform.position.x <= player.transform.position.x - sceneElementWidth*2){
                Destroy(sceneComponent);
            }
        }

        //If the player has fallen out of the Game
        if(player.transform.position.y <= -40){
            SceneManager.LoadScene("MaxTestGameOver");
        }
    }
}
