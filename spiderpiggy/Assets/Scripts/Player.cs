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
            if(jumpesInRow <= 3){
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
