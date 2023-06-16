using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrollState : MonoBehaviour
{
    public Transform[] wayPoints;
    public GameObject child;
    //public Color stateColor = Color.green;

    private StateMachineAgent stateMachine;
    private NavMeshController controllerNM;
    private int nextWayPoint;
    private Animator animator;
    // Start is called before the first frame update
    void Awake()
    {
        animator = child.GetComponent<Animator>();
        controllerNM = GetComponent<NavMeshController>();
        stateMachine = GetComponent<StateMachineAgent>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (controllerNM.Arrived())
        {
            nextWayPoint = (nextWayPoint + 1) % wayPoints.Length;
            ChangeDestiny();
        }
    }
    void OnEnable()
    {
        animator.SetBool("Alert", false);
        nextWayPoint = (nextWayPoint + 1) % wayPoints.Length;
        ChangeDestiny();
    }

    private void ChangeDestiny(){
        controllerNM.UpdateDestinyNavMeshAgent(wayPoints[nextWayPoint].position);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player") && stateMachine.actualState != stateMachine.chaseState){
            stateMachine.ActivateState(stateMachine.alertState);
        }
    }
}
