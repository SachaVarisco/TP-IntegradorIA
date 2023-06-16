using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour
{
    public float speed;

    private float horizontalMove;
    private float verticalMove;
    private bool isDeath = false;

    private Animator animator;
    private Rigidbody2D rb2D;
    private SpriteRenderer spriteRend;
    private int turrets;
    private int enemys;


    [Header("Life")]
    [SerializeField] public float life;
    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>();  
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = speed * Input.GetAxisRaw("Horizontal")  * Time.deltaTime;
        verticalMove = speed * Input.GetAxisRaw("Vertical")  * Time.deltaTime;
       
    }
    private void FixedUpdate()
    {
        if (!isDeath)
        {
            Move();
        }
    }

    private void Move(){
        if (Input.GetAxis("Horizontal")!= 0 || Input.GetAxis("Vertical")!= 0 )
        {
            transform.position += new Vector3(horizontalMove, verticalMove);
            animator.SetFloat("MoveX", horizontalMove);
            animator.SetFloat("MoveUp", verticalMove);
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
        animator.SetBool("IsAlive", false);
        isDeath = true;
    }

    public void Menu()
    {
      SceneManager.LoadScene("Menu");  
    }
   
}
