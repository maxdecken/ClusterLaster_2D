using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemCounterController : MonoBehaviour
{
    [SerializeField] private TMP_Text itemsCollectedText = null;
    private int itemsCollected = 0;

    // Start is called before the first frame update
    void Start()
    {
        itemsCollectedText.text = "Power-Ups: " + itemsCollected;
    }

    public void itemCollected(){
        itemsCollected ++;
        itemsCollectedText.text = "Power-Ups: " + itemsCollected;
    }

    public bool useItem(){
        if((itemsCollected - 1) > 0){
            itemsCollected --;
            itemsCollectedText.text = "Power-Ups: " + itemsCollected;
            return true;
        }else{
            return false;
        }
    }
}
