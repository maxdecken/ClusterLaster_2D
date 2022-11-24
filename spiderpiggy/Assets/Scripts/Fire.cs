using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.SceneManagement;

public class Fire : MonoBehaviour
{
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
         rb = this.GetComponent<Rigidbody2D>();
    }

  public void OnTriggerEnter2D(Collider2D other){
  if (other.gameObject.CompareTag("Rope")){
     Destroy(other.gameObject);
            Destroy(other.transform.parent.gameObject);
            Debug.Log("GETROFFEN");
            //RestartLevel();
   }
  }

/*  private void RestartLevel (){
SceneManager.LoadScene(SceneManager.getActiveScene().name);

  }*/
}
  
