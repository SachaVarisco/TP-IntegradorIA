using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : MonoBehaviour
{
    public GameObject child;

    private StateMachineAgent stateMachine;
    private NavMeshController controllerNM;
    private VisionController visionController;
    [SerializeField ]private Transform player;
    private Animator animator;
    void Awake()
    {
        animator = child.GetComponent<Animator>();
        stateMachine = GetComponent<StateMachineAgent>();
        controllerNM = GetComponent<NavMeshController>();
        visionController = GetComponent<VisionController>();  
    }
    void OnEnable(){
        animator.SetBool("Alert", false);
    }


    // Update is called once per frame
    void Update()
    {
        controllerNM.UpdateDestinyNavMeshAgent(player.position); 
    }
}
