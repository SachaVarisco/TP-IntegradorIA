using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrollState : MonoBehaviour
{
  public Transform[] wayPoints;
    //public Color stateColor = Color.green;

    private StateMachineAgent stateMachine;
    private NavMeshController controllerNM;
    private int nextWayPoint;
    // Start is called before the first frame update
    void Awake()
    {
        controllerNM = GetComponent<NavMeshController>();
        stateMachine = GetComponent<StateMachineAgent>();
        
    }

    // Update is called once per frame
    void Update()
    {
        //RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.forward);
        //Debug.DrawRay(transform.position, Vector2.forward, Color.red);
        if (controllerNM.Arrived())
        {
            nextWayPoint = (nextWayPoint + 1) % wayPoints.Length;
            ChangeDestiny();
        }
    }
    void OnEnable()
    {
        //stateMachine.meshRenIndicate.material.color = stateColor;
        nextWayPoint = (nextWayPoint + 1) % wayPoints.Length;
        ChangeDestiny();
    }

    private void ChangeDestiny(){
        controllerNM.UpdateDestinyNavMeshAgent(wayPoints[nextWayPoint].position);
    }
    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player") && enabled){
            stateMachine.ActivateState(stateMachine.alertState);
        }
    }
}
