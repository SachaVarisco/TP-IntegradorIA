using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
  [SerializeField] private float life;
  public bool lookLeft = true;
  private Transform player;

  void Start()
  { 
    player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
  }
  void Update()
  {
    float difX = transform.position.x - player.position.x;
    if (lookLeft && difX < 0)
    {
      Rotate();
    }
    if (!lookLeft && difX > 0)
    {
      Rotate();
    }
  }



  public void TakeDamage(float damage){
      life -= damage;

      if (life <= 0)
      {
        Destroy(gameObject);
      }
  }
  private void Rotate(){
      lookLeft = !lookLeft;
      Vector3 theScale = transform.localScale;
      theScale.x *= -1;
      transform.localScale = theScale;
  }
}
