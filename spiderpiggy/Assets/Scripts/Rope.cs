using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json.Serialization;
using UnityEngine;
using System.Linq;


public class Rope : MonoBehaviour
{
    [SerializeField] float speed = 0.8f;
    [SerializeField] float distance = 1.8f;

    [SerializeField] GameObject RopePivotPrefab;
    [SerializeField] GameObject player;
    private Rigidbody2D playerRigidbody;
    [SerializeField] GameObject lastRopePivot;
    private GameObject RopePivot;
    public List<GameObject> RopePivotConections = new List<GameObject>();
    private int ropePivotCount = 2;
    private LineRenderer lineRenderer;

    private Vector2 vectorToHook;
    public Vector2 hookTarget;
    
    private bool finished = false;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag ("Player");

        lastRopePivot = transform.gameObject;
        
        RopePivotConections.Add(transform.gameObject);

        lineRenderer = GetComponent<LineRenderer>();
        playerRigidbody = player.GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards (transform.position, hookTarget, speed);
  
        if((Vector2)transform.position != hookTarget)
        {
            
            if (Vector2.Distance(player.transform.position, lastRopePivot.transform.position) > distance)
            {
                
                CreateRopePivot();
            }   
            
        }else if (finished == false)
        {
            finished = true;
            lastRopePivot.GetComponent<HingeJoint2D>().connectedBody = player.GetComponent<Rigidbody2D>();
        }
        RenderLine();
        
        
        
        //Get up while swinging
        
        if(Input.GetKeyDown(KeyCode.Q) && RopePivotConections.Any())
        {
            vectorToHook = hookTarget- (Vector2)player.transform.position;
            
            RopePivot.GetComponent<Rigidbody2D>().AddForce(new Vector2(0,  vectorToHook.y*20));
            playerRigidbody.AddForce(new Vector2(-vectorToHook.x*30,  vectorToHook.y*30));

        }   
        
    }

    // Render Line between Player and Target through Pivotpoints
    void RenderLine()
    {
        lineRenderer.SetVertexCount(ropePivotCount);
        int i;
        for (i = 0; i < RopePivotConections.Count; i++)
        {
            lineRenderer.SetPosition(i, RopePivotConections[i].transform.position);
        }

        lineRenderer.SetPosition(i, player.transform.position);
        //playerRigidbody.AddForce(new Vector2(0,  vectorToHook.y*300));
    }
    
    void CreateRopePivot()
    {
        
        Vector2 pos2Create = player.transform.position - lastRopePivot.transform.position;
        pos2Create.Normalize();
        pos2Create *= distance;
        pos2Create += (Vector2)lastRopePivot.transform.position;

        RopePivot = (GameObject) Instantiate(RopePivotPrefab, pos2Create, Quaternion.identity);
        
        RopePivot.transform.SetParent(transform);
        
        lastRopePivot.GetComponent<HingeJoint2D>().connectedBody = RopePivot.GetComponent<Rigidbody2D>();

        lastRopePivot = RopePivot;
        
        RopePivotConections.Add(lastRopePivot);
        ropePivotCount++;
    }


    public void DestroyRope()
    {
        Destroy(RopePivot.transform.parent);
    }
    
}
