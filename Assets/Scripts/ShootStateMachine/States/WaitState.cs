using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitState : MonoBehaviour
{
    private Animator animator;
    private StateMachineShoot stateMachine;
    // Start is called before the first frame update
    void Awake()
    {
        animator = GetComponent<Animator>();
        stateMachine = GetComponent<StateMachineShoot>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")){
            animator.SetBool("Shoot", true);
            stateMachine.ActivateState(stateMachine.shotState);
        }
        
    }
}
