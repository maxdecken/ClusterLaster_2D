using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemCounterController : MonoBehaviour
{
    [SerializeField] private AudioSource pickupItemSound = null;
    [SerializeField] private AudioSource activateItemSound = null;
    [SerializeField] private HighScoreController highScoreController = null;
    [SerializeField] private GameObject player = null;
    [SerializeField] private GameObject jumpActiveDisplay = null;
    [SerializeField] private GameObject scoreBoosterActiveDisplay = null;
    [SerializeField] private GameObject invincibilityActiveDisplay = null;
    [SerializeField] private GameObject timefreezeActiveDisplay = null;
    [SerializeField] private float powerUpDurationValue = 10f;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void itemCollected(string itemType){
        //Play Sound
        pickupItemSound.Play();

        if(itemType == "jumpItem"){
            player.GetComponent<Player>().ActivateJumpPower(jumpActiveDisplay);
        }else if(itemType == "scoreBoostItem"){
            highScoreController.scoreBooster(scoreBoosterActiveDisplay);
        }else if(itemType == "invincibilityItem"){
            player.GetComponent<Player>().ActivateInvincibility(invincibilityActiveDisplay);
        }else if(itemType == "timefreezeItem"){
            StartCoroutine(TimeFreezeActiveCorutine());
            GameEventManager.current.ItemTriggerEnter();
        }
    }

    public IEnumerator TimeFreezeActiveCorutine(){
        timefreezeActiveDisplay.SetActive(true);
        yield return new WaitForSeconds(powerUpDurationValue);
        timefreezeActiveDisplay.SetActive(false);
    }
}
