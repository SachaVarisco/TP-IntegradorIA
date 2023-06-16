using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public bool lookLeft = true;

    [SerializeField] private float life;
    [SerializeField] private GameObject child;
    private float velocityX;

    private Vector3 previousPosition;
    private VisionController vision;
    void Start() {
        previousPosition = transform.position;
    }

    void FixedUpdate()
    {
        Speed();
        if(velocityX > 0 && lookLeft){
            Rotate();
        }
        if (velocityX < 0 && !lookLeft)
        {
            Rotate();
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

        velocityX = (currentPosition.x - previousPosition.x) / deltaTime;

        previousPosition = currentPosition;

        return velocityX;
    }

    private void Rotate(){
        lookLeft = !lookLeft;
        Vector3 theScale = child.transform.localScale;
        theScale.x *= -1;
        child.transform.localScale = theScale;
    }
}
