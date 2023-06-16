using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlertState : MonoBehaviour
{
    public float setTime = 1;
    public GameObject child;
    
    private StateMachineAgent stateMachine;
    private NavMeshController controllerNM;
    private float currentTime;
    private Animator animator;
   
    void Awake()
    {
        animator = child.GetComponent<Animator>();
        stateMachine = GetComponent<StateMachineAgent>();
        controllerNM = GetComponent<NavMeshController>();
    }

    void OnEnable(){
        currentTime = setTime;
        controllerNM.StopNavMeshAgent();
        animator.SetBool("Alert", true);
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= Time.deltaTime;
        if(currentTime <= 0){
            stateMachine.ActivateState(stateMachine.chaseState);
            return;
        }
    }
}
