using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] Rigidbody2D playerRigidbody = null;
    [SerializeField] float strenghtMove = 10;
    [SerializeField] float strenghtJump = 100;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Jump
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W)){
            playerRigidbody.AddForce(new Vector2(0f,  strenghtJump));
        }
        //Move Left
        if(Input.GetKey(KeyCode.A)){
            playerRigidbody.AddForce(new Vector2(-strenghtMove, 0f));
        }
        //Move Right
        if(Input.GetKey(KeyCode.D)){
            playerRigidbody.AddForce(new Vector2(strenghtMove, 0f));
        }
    }
}
