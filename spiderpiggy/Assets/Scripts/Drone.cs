using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drone : MonoBehaviour
{
    public float speed = -3.0f;
    private Rigidbody2D rb;
    private Vector3 enemyPos;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(speed, 4 * Mathf.Sin(Time.time * 3.5f));

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
}
