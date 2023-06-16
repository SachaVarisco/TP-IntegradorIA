using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathState : MonoBehaviour
{
    private Animator animator;
    


    void OnEnable()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("IsDead", true);
    }
    void Scene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);   
    }

}
