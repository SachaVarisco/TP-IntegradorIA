using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Horizontal")!= 0 || Input.GetAxis("Vertical")!= 0 )
        {
            transform.position += new Vector3(speed * Input.GetAxisRaw("Horizontal") * Time.deltaTime, speed * Input.GetAxisRaw("Vertical") * Time.deltaTime);
        }
        if (Input.GetAxisRaw("Fire1") !=0 || Input.GetAxisRaw("Fire2") !=0  )
        {
            if (Input.GetAxisRaw("Fire1") == 1)
            {
                transform.rotation = Quaternion.Euler(0,0,0);
            }
            else if (Input.GetAxisRaw("Fire1") == -1)
            {
                transform.rotation = Quaternion.Euler(0,0,180);
            }
            else if (Input.GetAxisRaw("Fire2") == 1)
            {
                transform.rotation = Quaternion.Euler(0,0,90);
            }
            else if (Input.GetAxisRaw("Fire2") == -1)
            {
                transform.rotation = Quaternion.Euler(0,0,270);
            }
            
        }
        
    }
}
