using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotState : MonoBehaviour
{
    private float setTime = 1;
    private float currentTime;
    private Transform player;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform bulletController;
    private Animator animator;
    private StateMachineShoot stateMachine;
    // Start is called before the first frame update
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        animator = GetComponent<Animator>();
        stateMachine = GetComponent<StateMachineShoot>();
    }
    void OnEnable()
    {
        currentTime = setTime;
        Instantiate(bulletPrefab, bulletController.position, Quaternion.identity);    
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= Time.deltaTime;
        if(currentTime <= 0){
            animator.SetBool("Shoot", false);
            stateMachine.ActivateState(stateMachine.waitState);
            return;
        }
    }
}
