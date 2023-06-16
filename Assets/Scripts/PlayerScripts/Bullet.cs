using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float damage;

    
    public LayerMask layerToInteractWith;

    void Start()
    {
        int currentLayer = gameObject.layer;
        Physics2D.IgnoreLayerCollision(currentLayer, layerToInteractWith, true);

    }
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy")){
            other.transform.parent.GetComponent<Enemy>().TakeDamage(damage);
            Destroy(gameObject);
        }
        if (other.CompareTag("Turret")){
            
            other.GetComponent<Turret>().TakeDamage(damage);
            Destroy(gameObject);
        }
        if (other.CompareTag("Boss")){
            other.GetComponent<BossLifeController>().TakeDamage(damage);
            Destroy(gameObject);
        }
        if (other.CompareTag("wall")){
            Destroy(gameObject);
        }
        

    }
}
