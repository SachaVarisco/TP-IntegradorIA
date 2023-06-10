using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public bool lookLeft = true;

    [SerializeField] private float life;

    private Vector3 previousPosition;
    void Start() {
        previousPosition = transform.position;
    }

    void FixedUpdate()
    {
        if(Speed() > 0&& !lookLeft){
            Rotate();
        }else{
            if (Speed() < 0 && lookLeft)
            {
                Rotate();
            }
        }
    }

    public void TakeDamage(float damage){
        life -= damage;

        if (life <= 0)
        {
            Death();
        }
    }

    public void Death(){
        Destroy(gameObject);
    } 

    private float Speed()
    {
        Vector3 currentPosition = transform.position;
        float deltaTime = Time.deltaTime;

        float velocityX = (currentPosition.x - previousPosition.x) / deltaTime;

        previousPosition = currentPosition;

        return velocityX;
    }

    private void Rotate(){
        lookLeft = !lookLeft;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
