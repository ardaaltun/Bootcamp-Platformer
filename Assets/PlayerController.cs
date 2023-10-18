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
    public void Update()
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
        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, 0.7f);

        if (Input.GetKeyDown(KeyCode.W))
        {
            if (isGrounded)
            {
                //rb.AddForce(Vector2.up * Time.deltaTime * jumpForce, ForceMode2D.Impulse);
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {

            
            animator.SetBool("idle", false);
            animator.SetBool("run", false);
            animator.SetTrigger("attack");
        }
        if(rb.velocity.x > 2.0f) rb.velocity.Set(2.0f, rb.velocity.y);
        if(rb.velocity.x < -2.0f) rb.velocity.Set(-2.0f, rb.velocity.y);
    }
    public void Attack()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right, 1f);
        if (hit && hit.collider.GetComponent<EnemyController>())
            hit.collider.GetComponent<EnemyController>().Die();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name.StartsWith("h"))
        {
            CanvasController.instance.CollectHeart();
            Destroy(collision.gameObject);
        }
    }
}
