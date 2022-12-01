using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector3 enemyPos;
    [SerializeField] private float freezeDurationValue = 10;
    [SerializeField] private float xVelocity = -2.0f;
    [SerializeField] private float gravitySpeed = -45.0f;
    private float rotateSpeed = 40.0f;
    private float xFreeze = 0;
    private float yFreeze = 0;
    private float rotateFreeze = 0;
    private Action a;

    // Start is called before the first frame update
    void Start()
    {
        Action a = () => MeteorActivateTimeStop();
        GameEventManager.current.OnItemTriggerEnter += a;
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = new Vector2(xVelocity - xFreeze, gravitySpeed - yFreeze);
        transform.Rotate(0,0, (rotateSpeed - rotateFreeze) * Time.deltaTime);
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
    
    public IEnumerator MeteorActivateTimeStopCoroutine()
    {
        xFreeze = xVelocity;
        yFreeze = gravitySpeed;
        rotateFreeze = rotateSpeed;
        yield return new WaitForSeconds(freezeDurationValue);
        xFreeze = 0;
        yFreeze = 0;
        rotateFreeze = 0;
        GameEventManager.current.OnItemTriggerEnter -= a;
    }
    
    public void MeteorActivateTimeStop()
    {
        if (this != null)
        {
            StartCoroutine(MeteorActivateTimeStopCoroutine());
        }
    }
}