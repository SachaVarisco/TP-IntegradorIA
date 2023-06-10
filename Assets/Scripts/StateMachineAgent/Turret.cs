using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform bulletController;
    [SerializeField] private float life;
    private Animator animator;
    private Transform player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        animator = GetComponent<Animator>();
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Instantiate(bulletPrefab, bulletController.position, Quaternion.identity);
    }

    public void TakeDamage(float damage){
        life -= damage;

        if (life <= 0)
        {
          Destroy(gameObject);
        }
    }
}
