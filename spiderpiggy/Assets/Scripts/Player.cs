using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json.Serialization;
using UnityEngine;
using UnityEngine.Rendering.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] private HighScoreController highScoreController = null;
    [SerializeField] private ItemCounterController itemController = null;
    [SerializeField] private Rigidbody2D playerRigidbody = null;
    [SerializeField] private float strenghtMove = 10;
    [SerializeField] private float strenghtJump = 20;
    [SerializeField] private float powerUpDurationValue = 10;
    [SerializeField] private ForceMode2D forceModeMovement = ForceMode2D.Force;
    public bool isInvincible = false;
    

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
            }
        }
        //Move Left
        if(Input.GetKey(KeyCode.A)){
            playerRigidbody.AddForce(new Vector2(-strenghtMove, 0f), forceModeMovement);
            jumpesInRow = 0;
            playerAnimator.SetBool("isRolling", true);
        }
        //Move Right
        else if(Input.GetKey(KeyCode.D)){
            playerRigidbody.AddForce(new Vector2(strenghtMove, 0f), forceModeMovement);
            jumpesInRow = 0;
            playerAnimator.SetBool("isRolling", true);
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


    public IEnumerator ActivateJumpPowerCoroutine()
    {
        Debug.Log("You are jumpy!");
        strenghtJump = strenghtJump * 6; 
        yield return new WaitForSeconds(powerUpDurationValue);
        strenghtJump = strenghtJump / 6; 
        Debug.Log("You are not jumpy!");  
    }
    
    public void ActivateJumpPower()
    {
        StartCoroutine(ActivateJumpPowerCoroutine());
    }
    
    public IEnumerator ActivateInvincibilityCoroutine()
    {
        Debug.Log("You are invincible!"); 
        isInvincible = true; 
        yield return new WaitForSeconds(powerUpDurationValue);
        isInvincible = false; 
        Debug.Log("You are not invincible!");   
    }
    
    public void ActivateInvincibility()
    {
        StartCoroutine(ActivateInvincibilityCoroutine());
    }
    
    private void OnTriggerEnter2D(Collider2D collider){
        if(collider.gameObject.CompareTag("Enemy") && !isInvincible){
            SceneManager.LoadScene("GameOver");
        }
    }
    
}
