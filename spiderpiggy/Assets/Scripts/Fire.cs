using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fire : MonoBehaviour
{
  [SerializeField] private Player player = null;
  private Rigidbody2D rb;

  // Start is called before the first frame update
  void Start()
  {
    if(player == null){
      player = FindObjectOfType<Player>();
    }
    rb = this.GetComponent<Rigidbody2D>();
  }

private void OnTriggerEnter2D(Collider2D other){
  Debug.Log(other.gameObject.name);
  if(other.gameObject.name == player.gameObject.name){
    SceneManager.LoadScene("GameOver");
  }
}
}
  
