using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float damage;


    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy")){
            other.GetComponent<Enemy>().TakeDamage(damage);
        }
        if (other.CompareTag("Turret") && other.GetComponent<Collider2D>().GetType() == typeof(CircleCollider2D)){
            if (other.GetComponent<Collider2D>().GetType() == typeof(BoxCollider2D))
            {
                other.GetComponent<Turret>().TakeDamage(damage);
            } 
        }
        if (other.CompareTag("Boss")){
            other.GetComponent<BossLifeController>().TakeDamage(damage);
        }
        Destroy(gameObject);

    }
}
