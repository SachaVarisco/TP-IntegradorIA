using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisionController : MonoBehaviour
{
    public Transform eyes;
    public Transform player;
    public float visionRange = 20f;
    //public Vector2 offset = new Vector3(0f,0.3f);
    [HideInInspector]
    private Vector2 direction;
    public Vector2 forward;
    private NavMeshController controllerNM;
    private RaycastHit2D hit;

    void Awake(){
        controllerNM = GetComponent<NavMeshController>();
        forward = eyes.right;
    }
  
    public void Update(){
        direction = forward;
        hit = Physics2D.Raycast(eyes.position, direction, visionRange);
        Debug.DrawRay(eyes.position, direction * visionRange, Color.red);   

        
    }

    public bool SeePlayer(/*out RaycastHit2D hit*/ bool SeePlayer = false){
        
        if(SeePlayer == true){ 
            direction = (player.position) - eyes.position;
        } else
        {
            direction = eyes.right;
        }
        return hit.collider != null && hit.collider.CompareTag("Player");
    }

}
