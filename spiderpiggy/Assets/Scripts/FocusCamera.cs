using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FocusCamera : MonoBehaviour
{
    [SerializeField] GameObject player = null;
    [SerializeField] public float speed = 0;
    private float lastPosX = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(lastPosX < player.transform.position.x){
            lastPosX = player.transform.position.x;
        }
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(lastPosX, player.transform.position.y, transform.position.z), speed * Time.deltaTime);
    }
}
