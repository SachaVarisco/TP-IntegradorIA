using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisionController : MonoBehaviour
{
    public Transform eyes;
    public Transform player;
    public float visionRange = 20f;
    //public Vector2 offset = new Vector3(0f,0.3f);

    private Vector2 direction;
    private RaycastHit2D hit;
    private NavMeshController controllerNM;

    void Awake(){
        controllerNM = GetComponent<NavMeshController>();
    }
  
    public void Update(){
        direction = eyes.right;
        hit = Physics2D.Raycast(eyes.position, direction, visionRange);
        Debug.DrawRay(eyes.position, direction * visionRange, Color.red);   

        if(hit.collider != null && hit.collider.CompareTag("Player")){
            Debug.Log("Chocó con: " + hit.collider.gameObject.name);
        }
    }

    public bool SeePlayer( bool SeePlayer = false){
        
        if(SeePlayer == true){ 
            direction = (player.position) - eyes.position;
        } else
        {
            direction = eyes.right;
        }
        return hit.collider != null && hit.collider.CompareTag("Player");
    }
    /*public bool SeePlayer(out RaycastHit hit, bool seePlayer = false){
        Vector2 direction = eyes.right;
        
        if(seePlayer == true){ 
            direction = (player.position) - eyes.position;
        } else
        {
            direction = eyes.right;
        }
        Debug.DrawRay(eyes.position, direction * visionRange, Color.red);
        return Physics2D.Raycast(eyes.position, direction, visionRange) && hit.collider.CompareTag("Player");
    }*/
}
