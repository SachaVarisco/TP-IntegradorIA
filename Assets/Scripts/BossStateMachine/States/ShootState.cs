using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootState : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform bulletController;
    private Animator animator;
    private Transform player;
    private StateMachineBoss stateMachine;
   

    private float actualTime;
    private float stateTime = 1;
    // Start is called before the first frame update
    void OnEnable()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        animator = GetComponent<Animator>();
        stateMachine = GetComponent<StateMachineBoss>();

        actualTime = stateTime;
    }

    // Update is called once per frame
    void Update()
    {
        actualTime -= Time.deltaTime;
        if (actualTime <= 0)
        {
            animator.SetBool("Shoot", false);
            stateMachine.ActivateState(stateMachine.idleState);
        }

    }
    private void Bullet(){
        Instantiate(bulletPrefab, bulletController.position, Quaternion.identity);
    }
}
