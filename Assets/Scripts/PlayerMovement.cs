using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float jumpForce;
    private new Rigidbody2D rigidbody2D;
    // Start is called before the first frame update
    void Start()
    {
        this.rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position -= new Vector3(0f, movementSpeed * Time.deltaTime, 0f);
        if(Input.GetKeyDown("space")){
            rigidbody2D.velocity = new Vector2(0f, 0f);
            rigidbody2D.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
    }

    private void OnTriggerEnter2D(Collider2D other){
        Debug.Log("Ai!");
    }
}
