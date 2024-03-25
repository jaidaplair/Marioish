using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed = 4f;
    [SerializeField] float forceX = 1f;
    [SerializeField] float forceY = 10f;
    // Start is called before the first frame update
    Rigidbody2D rb;
    bool onGround = false;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                //transform.Translate(speed*Time.deltaTime*Vector2.left);
                rb.AddForce(forceX * Vector2.left);
            }
            if (Input.GetKey(KeyCode.Space))
            {
                rb.AddForce(forceY * Vector2.up);//applying upward force
            }
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            onGround = true;
        }


    }

    private void OnCollisionExit2D (Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            onGround = false;
        }

    }

}
