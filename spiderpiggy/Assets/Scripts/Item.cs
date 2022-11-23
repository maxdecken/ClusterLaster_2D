using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private string itemType = "";
    [SerializeField] private Player player = null;
    [SerializeField] private ItemCounterController itemCounter = null;

    void Start(){
        if(player == null){
            player = FindObjectOfType<Player>();
        }
        if(itemCounter == null){
            itemCounter = FindObjectOfType<ItemCounterController>();
        }
    }
    
    private void OnTriggerEnter2D(Collider2D collider){
        //Debug.Log(collider.gameObject.name);
        if(collider.gameObject.name == player.gameObject.name){
            itemCounter.itemCollected(itemType);
            Destroy(this.gameObject);
        }
    }
}
