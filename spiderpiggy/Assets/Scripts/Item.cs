using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] Player player = null;
    [SerializeField] ItemCounterController itemCounter = null;

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
            itemCounter.itemCollected();
            Destroy(this.gameObject);
        }
    }
}
