using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlertState : MonoBehaviour
{
    /*public float spinSpeed = 120f;
    public float setTime = 4;
    
    private StateMachineAgent stateMachine;
    private NavMeshController controllerNM;
    private VisionController visionController;
    private float currentTime;
   
    void Awake()
    {
        
        stateMachine = GetComponent<StateMachineAgent>();
        controllerNM = GetComponent<NavMeshController>();
        visionController = GetComponent<VisionController>();
    }

    void OnEnable(){
        currentTime = setTime;
        controllerNM.StopNavMeshAgent();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if(visionController.SeePlayer(out hit)){
            controllerNM.objective = hit.transform;
            stateMachine.ActivateState(stateMachine.chaseState);
            return;
        }
        transform.Rotate(0f, spinSpeed * Time.deltaTime, 0f);
        
        currentTime -= Time.deltaTime;
        if(currentTime <= 0){
            stateMachine.ActivateState(stateMachine.patrollState);
            return;
        }
    }*/
}
