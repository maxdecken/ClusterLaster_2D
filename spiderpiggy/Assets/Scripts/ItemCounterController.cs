using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemCounterController : MonoBehaviour
{
    [SerializeField] private TMP_Text jumpItemsCollectedText = null;
    [SerializeField] private TMP_Text scoreBoostItemsCollectedText = null;
    [SerializeField] private TMP_Text invincibilityItemsCollectedText = null;
    [SerializeField] private TMP_Text timefreezeItemsCollectedText = null;
    [SerializeField] private AudioSource pickupItemSound = null;
    [SerializeField] private AudioSource activateItemSound = null;
    private int jumpItemsCollected = 0;
    private int scoreBoostItemsCollected = 0;
    private int invincibilityItemsCollected = 0;
    private int timefreezeItemsCollected = 0;

    // Start is called before the first frame update
    void Start()
    {
        jumpItemsCollectedText.text = "Big Jumps: " + jumpItemsCollected;
        scoreBoostItemsCollectedText.text = "Score Booster: " + scoreBoostItemsCollected;
        invincibilityItemsCollectedText.text = "Invincibility: " + invincibilityItemsCollected;
        timefreezeItemsCollectedText.text = "Freeze Time: " + timefreezeItemsCollected;
    }

    public void itemCollected(string itemType){
        if(itemType == "jumpItem"){
            jumpItemsCollected ++;
            jumpItemsCollectedText.text = "Big Jumps: " + jumpItemsCollected;
        }else if(itemType == "scoreBoostItem"){
            scoreBoostItemsCollected ++;
            scoreBoostItemsCollectedText.text = "Score Booster: " + scoreBoostItemsCollected;
        }else if(itemType == "invincibilityItem"){
            invincibilityItemsCollected ++;
            invincibilityItemsCollectedText.text = "Invincibility: " + invincibilityItemsCollected;
        }else if(itemType == "timefreezeItem"){
            timefreezeItemsCollected ++;
            timefreezeItemsCollectedText.text = "Freeze Time: " + timefreezeItemsCollected;
        }
        pickupItemSound.Play();
    }

    public bool useItem(string itemType){
        if(itemType == "jumpItem" && jumpItemsCollected >= 1){
            jumpItemsCollected --;
            jumpItemsCollectedText.text = "Big Jumps: " + jumpItemsCollected;
        }else if(itemType == "scoreBoostItem" && scoreBoostItemsCollected >= 1){
            scoreBoostItemsCollected --;
            scoreBoostItemsCollectedText.text = "Score Booster: " + scoreBoostItemsCollected;
        }else if(itemType == "invincibilityItem" && invincibilityItemsCollected >= 1){
            invincibilityItemsCollected --;
            invincibilityItemsCollectedText.text = "Invincibility: " + invincibilityItemsCollected;
        }else if(itemType == "timefreezeItem" && timefreezeItemsCollected >= 1){
            timefreezeItemsCollected --;
            timefreezeItemsCollectedText.text = "Freeze Time: " + timefreezeItemsCollected;
        }else{
            return false;
        }
        activateItemSound.Play();
        return true;
    }
}
