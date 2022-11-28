using System;
using System.Collections;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class HookAnchor : MonoBehaviour
{
    [SerializeField] SpriteRenderer targetSprite;
    [SerializeField] Transform target;
    private Vector2 hookTarget;
    private Vector2 mousePosition;
    private float maxDistance = 30f;
    public GameObject hook;

    private GameObject currentHook;

    private bool ropeIsActive = false;
    private bool hookAble = false;
    
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
        SetTargetPosition();
        if (Input.GetMouseButtonDown(0))
        {


            if (ropeIsActive == false && hookAble)
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


    private void SetTargetPosition(){
        
        // Mausposition bestimmen
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
       
        
        var x = mousePosition.x;
        var y = mousePosition.y;

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
            hookAble = true;
            targetPosition = new Vector3(hit.point.x, hit.point.y, 0);
            target.transform.position = targetPosition;
            

            hookTarget = new Vector2(hit.point.x, hit.point.y);
        }
        else
        {
            hookAble = false;
        }
        
        
        
    }

    private void FixedUpdate()
    {
        
    }

   
}

