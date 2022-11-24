using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private HighScoreController highScoreController = null;
    [SerializeField] private ItemCounterController itemController = null;
    [SerializeField] private Rigidbody2D playerRigidbody = null;
    [SerializeField] private float strenghtMove = 10;
    [SerializeField] private float strenghtJump = 100;
    [SerializeField] private ForceMode2D forceModeMovement = ForceMode2D.Force;
    [SerializeField] private AudioSource stepSound = null;
    [SerializeField] private AudioSource jumpSound = null;

    private Animator playerAnimator;
    private int jumpesInRow = 0;
    // Start is called before the first frame update
    void Start()
    {
        playerAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Jump
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W)){
            if(jumpesInRow <= 4){
                playerRigidbody.AddForce(new Vector2(0f,  strenghtJump));
                jumpesInRow++;
                jumpSound.Play();
            }
        }
        //Move Left
        if(Input.GetKey(KeyCode.A)){
            playerRigidbody.AddForce(new Vector2(-strenghtMove, 0f), forceModeMovement);
            jumpesInRow = 0;
            playerAnimator.SetBool("isRolling", true);
            stepSound.Play();
        }
        //Move Right
        else if(Input.GetKey(KeyCode.D)){
            playerRigidbody.AddForce(new Vector2(strenghtMove, 0f), forceModeMovement);
            jumpesInRow = 0;
            playerAnimator.SetBool("isRolling", true);
            stepSound.Play();
        }
        else {
            playerAnimator.SetBool("isRolling", false);
        }
        

        //Use Items:
        //Use ScoreBoost
        if(Input.GetKeyDown(KeyCode.E)){
            if(itemController.useItem("scoreBoostItem")){
                highScoreController.scoreBooster();
            }
        }
    }
}
