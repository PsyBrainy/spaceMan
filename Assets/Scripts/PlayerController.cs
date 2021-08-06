using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float jumpForce = 6f;
    public float runningSpeed = 2f;

    Rigidbody2D rigidbody;
    Animator animator;

    const string STATE_ALIVE = "isAlive";
    const string STATE_ON_THE_GROUND = "isOnTheGraund";
    

    public LayerMask groundMask;


    
    void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Start()
    {
        animator.SetBool(STATE_ALIVE, true);
        animator.SetBool(STATE_ON_THE_GROUND, true);
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)){
            Jump();
        }

        animator.SetBool(STATE_ON_THE_GROUND, IsTouchingTheGround());


        Debug.DrawRay(this.transform.position, Vector2.down * 1.5f, UnityEngine.Color.red);
    }

    void FixedUpdate()
    {
        if (rigidbody.velocity.x < runningSpeed){
            rigidbody.velocity = new Vector2(runningSpeed, rigidbody.velocity.y);
        }
    }




    void Jump(){
        if (IsTouchingTheGround()){
            rigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
        
    }

    // Player toca el suelo?
    bool IsTouchingTheGround(){
        if (Physics2D.Raycast(this.transform.position, Vector2.down, 1.5f, groundMask)){

            // TODO: programar logica contacto con el suelo
            
            return true;

        }else {

            //TODO: programar logica de no contacto

            return false;

        }
    }
}
