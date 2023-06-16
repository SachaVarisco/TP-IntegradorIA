using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (CountEntitiesWithTag("Turret") <= 0 && CountEntitiesWithTag("Enemy") <= 0)
        {
            animator.SetBool("Finish", true);
        }
    }

    private int CountEntitiesWithTag(string tag)
    {
        GameObject[] entities = GameObject.FindGameObjectsWithTag(tag);
        return entities.Length;
    }

     private void OnTriggerEnter2D(Collider2D other)
    {
        if (CountEntitiesWithTag("Turret") <= 0 && CountEntitiesWithTag("Enemy") <= 0){
            if (other.CompareTag("Player")){
                SceneManager.LoadScene("BossFightScene");
            }
        }
          
    }
}
