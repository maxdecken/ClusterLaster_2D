using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seagull : MonoBehaviour
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
        rb.velocity = new Vector2(-6 * Mathf.Cos(Time.time * 0.2f), 1.2f * Mathf.Cos(Time.time * 2));

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
