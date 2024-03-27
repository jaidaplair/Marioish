using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed = 4f;
    [SerializeField] float forceX = 1f;
    [SerializeField] float forceY = 10f;
    SpriteRenderer spriteRenderer;
    Animator animator;//create a reference to an animator type
    // Start is called before the first frame update
    Rigidbody2D rb;
    bool onGround = false;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (onGround)
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                //ransform.Translate(speed * Time.deltaTime * Vector2.right);
                rb.AddForce(forceX * Vector2.right);
                animator.SetBool("right", true);
                spriteRenderer.flipX = false;
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                //transform.Translate(speed*Time.deltaTime*Vector2.left);
                rb.AddForce(forceX * Vector2.left);
                animator.SetBool("right", false);
                spriteRenderer.flipX = true;
            }
            if (Input.GetKey(KeyCode.Space))
            {
                rb.AddForce(forceY * Vector2.up);//applying upward force
                animator.SetBool("jump", true);
                spriteRenderer.flipX = false;
                
            }
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            onGround = true;
            animator.SetBool("jump", false);
        }


    }

    private void OnCollisionExit2D (Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            onGround = false;
            animator.SetBool("jump", true);
        }

    }

}
