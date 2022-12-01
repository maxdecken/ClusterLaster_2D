using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json.Serialization;
using UnityEngine;
using UnityEngine.Rendering.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    //[SerializeField] private ItemCounterController itemController = null;
    [SerializeField] private Rigidbody2D playerRigidbody = null;
    [SerializeField] private float strenghtMove = 12;
    [SerializeField] private float strenghtJump = 20;
    [SerializeField] private float powerUpDurationValue = 10;
    [SerializeField] private ForceMode2D forceModeMovement = ForceMode2D.Force;
    public bool isInvincible = false;
    

    private Animator playerAnimator;
    private int jumpesInRow = 0;
    private float jumpOffTimeStart = 0;
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
            //Limit Players max. y-velocity and y height to prevent to high jumpes
            Vector3 playerVelocity = playerRigidbody.velocity;
                if(playerVelocity.y <= 2 && gameObject.transform.position.y < 22){
                //If more then 3 Jumps in a row the next jump can be executed one sec. after
                if(jumpOffTimeStart != 0 && Time.time - jumpOffTimeStart > 1.5f){
                    jumpOffTimeStart = 0;
                    jumpesInRow = 0;
                }
                if(jumpesInRow <= 3){
                    playerRigidbody.AddForce(new Vector2(0f,  strenghtJump));
                    jumpesInRow++;
                    if(jumpesInRow > 3){
                        jumpOffTimeStart = Time.time;
                    }
                }
            }
        }
        //Move Left
        if(Input.GetKey(KeyCode.A)){
            //Limit Players max. x-velocity to prevent "flying" in the scene
            Vector3 playerVelocity = playerRigidbody.velocity;
                if(playerVelocity.x <= 7.5){
                    playerRigidbody.AddForce(new Vector2(-strenghtMove, 0f), forceModeMovement);
                    playerAnimator.SetBool("isRolling", true);
                }
        }
        //Move Right
        else if(Input.GetKey(KeyCode.D)){
            //Limit Players max. x-velocity to prevent "flying" in the scene
            Vector3 playerVelocity = playerRigidbody.velocity;
                if(playerVelocity.x <= 7.5){
                    playerRigidbody.AddForce(new Vector2(strenghtMove, 0f), forceModeMovement);
                    playerAnimator.SetBool("isRolling", true);
                }
        }
        else {
            playerAnimator.SetBool("isRolling", false);
        }
        //End Game if player presssed ESC
        if(Input.GetKey(KeyCode.Escape)){
            SceneManager.LoadScene("GameOver");
        }
    }


    public IEnumerator ActivateJumpPowerCoroutine(GameObject displayActive)
    {
        displayActive.SetActive(true);
        strenghtJump = strenghtJump * 2; 
        yield return new WaitForSeconds(powerUpDurationValue);
        strenghtJump = strenghtJump / 2;
        displayActive.SetActive(false);
    }
    
    public void ActivateJumpPower(GameObject displayActive)
    {
        StartCoroutine(ActivateJumpPowerCoroutine(displayActive));
    }
    
    public IEnumerator ActivateInvincibilityCoroutine(GameObject displayActive)
    {
        displayActive.SetActive(true);
        isInvincible = true; 
        yield return new WaitForSeconds(powerUpDurationValue);
        isInvincible = false;
        displayActive.SetActive(false);
    }
    
    public void ActivateInvincibility(GameObject displayActive)
    {
        StartCoroutine(ActivateInvincibilityCoroutine(displayActive));
    }
    
    private void OnTriggerEnter2D(Collider2D collider){
        if(collider.gameObject.CompareTag("Enemy") && !isInvincible){
            SceneManager.LoadScene("GameOver");
        }
    }
    
}
