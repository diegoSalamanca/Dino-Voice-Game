//Codigo Desarrollado por Diego Salamanca
//Email: Diegocolmayor@gmail.com
//Tel. 301 733 7051
//Bogotá Colombia.

/*  Funcionamiento
Controlador de las animaciones y las físicas del personaje dinosaurio. 
 */

using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private bool  inAir,  crounch;

    
    public bool InAir { get { return inAir; } set { inAir = value; } }
    public bool Crounch { get { return crounch; } set { crounch = value; } }


    new Rigidbody2D rigidbody2D;

    public float speed;

    public float jumpForce;

    Animator animator;

    GameManager gameManager;

    Vector3 startPosition;


    void Start()
    {
        startPosition = transform.position;
        inAir = false;
        crounch = false;        
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        animator.SetTrigger("idle");
        gameManager = GameManager.instance;
    }

    public void StartGame()
    {
        animator.SetTrigger("walk");
        gameManager.Game = true;
        transform.position = startPosition;
    }
    
    
    void Update()
    {
        if (gameManager.Game)
        {
            rigidbody2D.velocity = new Vector2(speed, rigidbody2D.velocity.y);

            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                Jump();
                inAir = true;
            }

            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                Crouch();
                crounch = true;
            }
            
        }
        else
        {
            rigidbody2D.velocity = Vector2.zero;
        }
           
        

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Respawn"))
        {
            GameManager.instance.proceduralTerrain.Spawnground();            
        }

        if (collision.CompareTag("enemy"))
        {
            print("Dead");
            Dead();
            
        }
    }

    public void Jump()
    {
        if (rigidbody2D.velocity.y == 0)
        {
            
            rigidbody2D.AddForce(Vector2.up * jumpForce);
            animator.SetTrigger("jump");

        }
    }

    public void Crouch()
    {       
            animator.SetTrigger("crouch");
    }

    public void Endjump()
    {
        animator.SetTrigger("walk");
        inAir = false;
    }

    public void EndCrouch()
    {
        animator.SetTrigger("walk");
        crounch = false;
    }

    public void Dead()
    {
        if (GameManager.instance.Game)
        {
            animator.SetTrigger("dead");
            GameManager.instance.EndGame();
        }
             
    }

}
