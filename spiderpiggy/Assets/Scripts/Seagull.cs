using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seagull : MonoBehaviour
{
    public float speed = -3.0f;
    private Rigidbody2D rb;
    private Vector3 enemyPos;
    private Vector2 savedVelocity;
    [SerializeField] private float freezeDurationValue = 10;
    [SerializeField] private float xVelocity = -6;
    [SerializeField] private float yVelocity = 1.2f;
    private Vector3 characterScale;
    private float scaleSave;
    private float xFreeze = 0;
    private float yFreeze = 0;
    private Action a;

    // Start is called before the first frame update
    void Start()
    {
        Action a = () => SeagullActivateTimeStop();
        GameEventManager.current.OnItemTriggerEnter += a;
        rb = this.GetComponent<Rigidbody2D>();
        scaleSave = transform.localScale.x;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = new Vector2((xVelocity - xFreeze)   * Mathf.Cos(Time.time * 0.2f), (yVelocity - yFreeze) * Mathf.Cos(Time.time * 2));
        characterScale = transform.localScale;
        if (Mathf.Cos(Time.time * 0.2f) < 0)
        {
            characterScale.x = -scaleSave;
        }
        else
        {
            characterScale.x = scaleSave;
        }

        transform.localScale = characterScale;
        
        enemyPos = Camera.main.WorldToScreenPoint(transform.position);
    }
    
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Rope"))
        {
            Destroy(other.gameObject);
            Destroy(other.transform.parent.gameObject);
            Debug.Log("GETROFFEN");
        }
    }
    
    public IEnumerator SeagullActivateTimeStopCoroutine()
    {
        xFreeze = xVelocity;
        yFreeze = yVelocity;
        Debug.Log("Time is frozen");
        yield return new WaitForSeconds(freezeDurationValue);
        xFreeze = 0;
        yFreeze = 0;  
        Debug.Log("You are not frozen!"); 
        GameEventManager.current.OnItemTriggerEnter -= a;
    }
    
    private void SeagullActivateTimeStop()
    {
       StartCoroutine(SeagullActivateTimeStopCoroutine());
    }

    private void OnDoorwayOpen()
    {
        
    }
}