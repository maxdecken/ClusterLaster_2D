using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drone : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector3 enemyPos;
    [SerializeField] private float freezeDurationValue = 10;
    [SerializeField] public float xVelocity = -3.0f;
    [SerializeField] public float yVelocity = 4;
    private float xFreeze = 0;
    private float yFreeze = 0;
    private Action a;

    // Start is called before the first frame update
    void Start()
    {
        Action a = () => DroneActivateTimeStop();
        GameEventManager.current.OnItemTriggerEnter += a;
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = new Vector2((xVelocity - xFreeze), (yVelocity - yFreeze) * Mathf.Sin(Time.time * 3.5f));

        enemyPos = Camera.main.WorldToScreenPoint(transform.position);
    }
    
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Rope"))
        {
            Destroy(other.gameObject);
            if (other.transform.parent.gameObject)
            {
                Destroy(other.transform.parent.gameObject);
            }
            
        }
    }
    
    public IEnumerator DroneActivateTimeStopCoroutine()
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
    
    public void DroneActivateTimeStop()
    {
        if (this != null)
        {
            StartCoroutine(DroneActivateTimeStopCoroutine());
        }
    }
}