using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBullet : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float damage;

    private Transform player;
    private Rigidbody2D rb2D;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        rb2D = GetComponent<Rigidbody2D>();

        Vector3 direction = player.position - transform.position;
        rb2D.velocity = new Vector2(direction.x,direction.y).normalized * speed;
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")){
            other.GetComponent<PlayerController>().TakeDamage(damage);
            Destroy(gameObject);
        }
        
    }
}
