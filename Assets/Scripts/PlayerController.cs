using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Transform tf;
    private Rigidbody2D rb2d;
    private SpriteRenderer sr;
    private Animator animator;

    public float speed = 5.0f;
    public float jumpforce = 10.0f;
    public Transform groundPoint;
    public bool isGrounded = false;

    // Start is called before the first frame update
    void Start()
    {
        tf = gameObject.GetComponent<Transform>();
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        sr = gameObject.GetComponent<SpriteRenderer>();
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float xMovement = Input.GetAxis("Horizontal") * speed;
        rb2d.velocity = new Vector2(xMovement, rb2d.velocity.y);
        if (xMovement > 0)
        {
            sr.flipX = false;
            animator.Play("PlayerWalk");
        }
        else if (xMovement < 0)
        {
            sr.flipX = true;
            animator.Play("PlayerWalk");
        }
        else
        {
            animator.Play("PlayerIdle");
        }
        //Detect if player is on ground
        //isGrounded = false;
        RaycastHit2D hitinfo = Physics2D.Raycast(groundPoint.position, Vector2.down, 0.1f);
        if(hitinfo.collider !=null)
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
        //Jump
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            rb2d.AddForce(Vector2.up * jumpforce);
        }
    }
}
