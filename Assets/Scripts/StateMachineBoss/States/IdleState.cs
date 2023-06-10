using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : MonoBehaviour
{
    private Animator animator;
    private StateMachineBoss stateMachine;
    private Transform player;
    private BossLifeController boss;

    private float actualTime;
    private float stateTime = 1;
    
    // Start is called before the first frame update
    void OnEnable()
    {
        animator = GetComponent<Animator>();
        stateMachine = GetComponent<StateMachineBoss>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        boss = GetComponent<BossLifeController>();

        actualTime = stateTime;
    }

    
    void Update()
    {
        float playerDistance = Vector2.Distance(transform.position, player.position);
        actualTime -= Time.deltaTime;

        if (playerDistance < 2)
        {
            animator.SetBool("Melee", true);   
            stateMachine.ActivateState(stateMachine.meleeState);
        }
        if (actualTime <= 0 && boss.life > 0)
        {
            actualTime = stateTime;
            if (Number() % 2 == 0)
            {
                animator.SetBool("Shoot", true);
                stateMachine.ActivateState(stateMachine.shootState);
            }
        }
        
    }

    private float Number(){
        float random = Random.Range(1, 10);
        Debug.Log(random);
        return random;
    }
}
