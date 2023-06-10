using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLifeController : MonoBehaviour
{
     
    public float life;

    private Rigidbody2D rb2D; 
    private Animator animator;
    private Transform player;
    private StateMachineBoss stateMachine;


    
    void Start()
    {
        animator = GetComponent<Animator>();
        rb2D = GetComponent<Rigidbody2D>(); 
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        stateMachine = GetComponent<StateMachineBoss>();

    }

    // Update is called once per frame
    void Update()
    {
        if (life <= 15 && life > 10)
        {
            animator.SetBool("Damaged", true);
        }
        if (life <= 10 && life > 0)
        {
            animator.SetBool("VeryDam", true);
        }       
        if (life<=0)
        {
            animator.SetBool("Damaged", false);
            animator.SetBool("VeryDam", false);
            stateMachine.ActivateState(stateMachine.deathState);
            
        } 
    }

    public void TakeDamage(float damage){
        life -= damage;
    }

   
}
