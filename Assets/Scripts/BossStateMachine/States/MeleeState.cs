using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeState : MonoBehaviour
{
    private Rigidbody2D rb2D; 
    private Animator animator;
    private Transform player;
    private StateMachineBoss stateMachine;
    
    //private Boss boss;
    [Header("Attack")]
    [SerializeField] private Transform attackController;
    [SerializeField] private float attackRadius;
    [SerializeField] private float attackDamage;
    void OnEnable()
    {
        
        animator = GetComponent<Animator>();
        rb2D = GetComponent<Rigidbody2D>(); 
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        stateMachine = GetComponent<StateMachineBoss>();
    }

    // Update is called once per frame
    void Update()
    {       
        
        float playerDistance = Vector2.Distance(transform.position, player.position);
        if (playerDistance > 3)
        {
            animator.SetBool("Melee", false);
            stateMachine.ActivateState(stateMachine.idleState);
        }
        
    }

    public void Attack(){
        Collider2D[] objects = Physics2D.OverlapCircleAll(attackController.position, attackRadius);
        foreach (Collider2D collision in objects)
        {
            if (collision.CompareTag("Player"))
            {
                collision.GetComponent<PlayerController>().TakeDamage(attackDamage);
            }
            
        }
    }

    private void OnDrawGizmos(){
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackController.position, attackRadius);
    }
}
