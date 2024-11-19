using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jump_speed;
    private Rigidbody2D body;
    private Animator anim;
    private bool grounded;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>(); 
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);
        if(Input.GetKey(KeyCode.Space) && grounded){
            Jump();
        }
        anim.SetBool("grounded", grounded);
        anim.SetBool("run", horizontalInput != 0);
    }

    private void Jump(){
        body.velocity = new Vector2(body.velocity.x, jump_speed);
        anim.SetTrigger("jump");
        grounded = false;
    }

    private void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.tag == "Ground"){
            grounded = true;
        }
    }
}
