using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootPlayer : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;

    private float bulletTime;
    private float bulletDelay;
    private float bulletAngle;

    private Animator animator;
    void Start()
    {
       animator = GetComponent<Animator>(); 
       bulletDelay = 1;
       bulletTime = bulletDelay;
    }
    void Update()
    {
        Shoot();
        bulletTime -= Time.deltaTime;
    }

    private void Shoot(){
        if (Input.GetAxisRaw("Fire1") !=0 || Input.GetAxisRaw("Fire2") !=0  )
        {
            if (Input.GetAxisRaw("Fire1") == 1)
            {
                animator.Play("Gnome_ShootRight",-1,0f);
                bulletAngle = 0;
                Bullet();
            }
            else if (Input.GetAxisRaw("Fire1") == -1)
            {
                animator.Play("Gnome_ShootLeft",-1,0f);
                bulletAngle = 180;
                Bullet();
            }
            else if (Input.GetAxisRaw("Fire2") == 1)
            {
                animator.Play("Gnome_ShootUp",-1,0f);
                bulletAngle = 90;
                Bullet();
            }
            else if (Input.GetAxisRaw("Fire2") == -1)
            {
                animator.Play("Gnome_ShootDown",-1,0f);
                bulletAngle = 270;
                Bullet();
            }
            
        }
    }

    private void Bullet(){
        if (bulletTime < 0)
        {
            Instantiate(bulletPrefab, transform.position, Quaternion.Euler(0,0, bulletAngle));
            bulletTime = bulletDelay;
        }
    }
}
