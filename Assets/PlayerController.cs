using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed; 
    public float jumpForce;
    Rigidbody2D rb;
    Animator animator;
    SpriteRenderer renderer;
    public bool isGrounded;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        renderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.D))
        {
            renderer.flipX = false;
            rb.velocity = new Vector2(speed * Time.deltaTime, rb.velocity.y);
            animator.SetBool("idle", false);
            animator.SetBool("run", true);
        }

        else if (Input.GetKey(KeyCode.A))
        {
            renderer.flipX = true;
            rb.velocity = new Vector2(speed * Time.deltaTime * -1f, rb.velocity.y);
            animator.SetBool("idle", false);
            animator.SetBool("run", true);
        }
        else
        {
            animator.SetBool("idle", true);
            animator.SetBool("run", false);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            isGrounded = Physics2D.Raycast(transform.position, Vector2.down, 0.7f);
            if (isGrounded)
                rb.AddForce(Vector2.up * Time.deltaTime * jumpForce, ForceMode2D.Impulse);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {

            
            animator.SetBool("idle", false);
            animator.SetBool("run", false);
            animator.SetTrigger("attack");
        }
        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, 0.7f);

        Debug.DrawLine(transform.position, new Vector2(transform.position.x, transform.position.y - 1f), Color.green);
    }
}
