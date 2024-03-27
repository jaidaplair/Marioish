using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoggyController : MonoBehaviour
{
    // Start is called before the first frame update
    
    Animator animator;//create a reference to an animator type
    SpriteRenderer spriteRenderer;
    [SerializeField] float speed = 4f;
    void Start()
    {
        //reference to our animator component
       animator = GetComponent<Animator>();
       spriteRenderer = GetComponent<SpriteRenderer>();//get a reference to our spriteRenderer
    }

    // Update is called once per frame
    void Update()
    {
       // animator.SetBool("right", Input.GetKey(KeyCode.RightArrow));
        
        if (Input.GetKey(KeyCode.RightArrow))
        {
            animator.SetBool("right", true);//set the right parametor to true
            spriteRenderer.flipX = false;// dont wanna flip
            transform.Translate(Time.deltaTime * speed * Vector3.right);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            animator.SetBool("right", true);//set the right parameter top false
            spriteRenderer.flipX = true;//want ot flip
            transform.Translate(Time.deltaTime * speed * Vector3.left);
        }
        else
        {
            animator.SetBool("right", false);
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            animator.SetBool("up", true);//set the up parametor to true
            transform.Translate(Time.deltaTime * speed * Vector3.up);
        }
        else
        {
            animator.SetBool("up", false);//set the up parameter top false
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            animator.SetBool("down", true);//set the down parametor to true
            transform.Translate(Time.deltaTime * speed * Vector3.down);
        }
        else
        {
            animator.SetBool("down", false);//set the down parameter top false
        }
/*
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            animator.SetBool("right", true);//set the right parametor to true
            spriteRenderer.flipX = true;
        }
        else
        {
            animator.SetBool("right", false);//set the right parameter top false
            spriteRenderer.flipX = false;


        }*/
    }
}
