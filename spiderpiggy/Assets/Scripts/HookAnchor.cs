using System;
using System.Collections;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class HookAnchor : MonoBehaviour
{
    [SerializeField] SpriteRenderer targetSprite;
    [SerializeField] Transform target;
    private Vector2 hookTarget;
    private float maxDistance = 20f;
    public GameObject hook;

    private GameObject currentHook;

    private bool ropeIsActive = false;
    
    private BoxCollider2D playerHitBox;
    private Vector3 targetPosition;
    private int layermaskToHit;
    
    [SerializeField] private GameObject hitSquareBetween = null;

    
    private Animator playerAnimator;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        playerHitBox = GetComponent<BoxCollider2D>();
        layermaskToHit = 1 << LayerMask.NameToLayer("Hookable");
        playerAnimator = GetComponent<Animator>();
        Debug.Log(layermaskToHit);
    }

    // Update is called once per frame
    void Update()
    {
        setTargetPosition();
        if (Input.GetMouseButtonDown(0))
        {

            if (ropeIsActive == false)
            {
                currentHook = (GameObject) Instantiate(hook, transform.position, Quaternion.identity);

                currentHook.GetComponent<Rope>().hookTarget = hookTarget;

                ropeIsActive = true;

                playerAnimator.SetBool("isSwinging", true);
            }
            else
            {
                Destroy(currentHook);
                
                ropeIsActive = false;

                playerAnimator.SetBool("isSwinging", false);
            }
        }
        
        
       
    }


    private void setTargetPosition(){
        
        // Hook Target bestimmten
        hookTarget = Camera.main.ScreenToWorldPoint(Input.mousePosition);
       
        
        var x = hookTarget.x;
        var y = hookTarget.y;

        //hookTarget = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
        
        targetPosition = new Vector3(x, y, 0);
        target.transform.position = targetPosition;
        
        
        
        
        if (!targetSprite.enabled)
        {
            targetSprite.enabled = true;
        }
        
        
        // Hit ray um Hookables zu treffen
        var ray = new Ray2D(transform.position, targetPosition);
        
        RaycastHit2D hit = Physics2D.Raycast(transform.position, targetPosition - transform.position, maxDistance, layermaskToHit);
        
        Debug.DrawLine(transform.position,targetPosition);
        
        
        if (hit.collider != null)
        {
            targetPosition = new Vector3(hit.point.x, hit.point.y, 0);
            target.transform.position = targetPosition;

            hitSquareBetween.transform.position = new Vector3(hit.point.x, hit.point.y, 0);

            hookTarget = new Vector2(hit.point.x, hit.point.y);
        }
        else
        {
            // enter solution for non hit targetting
        }
        
        
        
    }

    private void FixedUpdate()
    {
        
    }

   
}

