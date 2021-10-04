using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float jumpForce;
    public float deathVelocity;
    private new Rigidbody2D rigidbody2D;
    private Animator animator;
    

    private enum State {
        Wait,
        Play,
        Dead,
    }

    [SerializeField]
    private State state;
    // Start is called before the first frame update
    void Start()
    {
        state = State.Play;
        this.rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case State.Wait:
                Idle();
                break;
            case State.Play:
                VerifyRigidBody();
                VerifyJump();
                break;
            case State.Dead:
                DeathPhysics();
                break;
        }
    }

    private void Idle(){
        rigidbody2D.bodyType = RigidbodyType2D.Static;
    }

    private void VerifyRigidBody(){
        if(this.rigidbody2D.bodyType == RigidbodyType2D.Static){
            rigidbody2D.bodyType = RigidbodyType2D.Dynamic;
        }
    }

    private void VerifyJump(){
        if(Input.GetKeyDown("space")){
            animator.ResetTrigger("Flap");
            animator.SetTrigger("Flap");
            rigidbody2D.velocity = new Vector2(0f, 0f);
            rigidbody2D.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
        //transform.LookAt(Vector3.right, Vector3.up);
    }

    private void DeathPhysics(){
        rigidbody2D.velocity = new Vector2(0f, deathVelocity);
    }

    private void OnTriggerEnter2D(Collider2D other){
        state = State.Dead;
    }
}
