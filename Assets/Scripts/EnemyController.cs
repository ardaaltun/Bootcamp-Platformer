using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    Rigidbody2D rb;
    Animator animator;
    SpriteRenderer renderer;
    public GameObject heart, key;
    public bool isRedEnemy;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        renderer = GetComponent<SpriteRenderer>();
    }

    public void Die()
    {
        animator.SetTrigger("death");
        GetComponent<BoxCollider2D>().enabled = false;
        transform.position = new Vector3(transform.position.x, transform.position.y - 0.25f, transform.position.z);
        if(isRedEnemy)
            Instantiate(heart, transform.position, Quaternion.identity);
        else
            Instantiate(key, transform.position, Quaternion.identity);
        Destroy(gameObject, 1.5f);
    }
}
