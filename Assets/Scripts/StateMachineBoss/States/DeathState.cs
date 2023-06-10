using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathState : MonoBehaviour
{
    private Animator animator;
    void OnEnable()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("IsDead", true);
    }
}
