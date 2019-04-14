using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimplePlatformerController : MonoBehaviour
{
    //Player Movement Variables
    [HideInInspector] public bool faceingRight = true;
    [HideInInspector] public bool jump = true;

    //Variable Constraints on Movement 
    public float moveForce = 365f;
    public float maxSpeed = 5f;
    public float jumpForce = 1000f;

    //Variable to Check if Player is on the Ground
    public Transform groundCheck;

    private bool grounded = false;
    private Animator anim;
    private Rigidbody2D rb2d;
       
    // Start is called before the first frame update
    void Start()
    {
        //Gets and Stores Components
        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Casts Line to Ground Layer
        grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));

        if (Input.GetButtonDown("Jump") && grounded)
        {
            jump = true;
        }
    }

    private void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        anim.SetFloat("Speed", Mathf.Abs(h));  //Mathf.Abs -> Moving Left or Right Get Positive

        //Checks if Player is Less Then Max Speed
        if (h * rb2d.velocity.x < maxSpeed)
        {
            rb2d.AddForce(Vector2.right * h * moveForce); //if Vector2 becomes Negative Player Goes Left
        }

        //Checks if Player is Greater Then Max Speed
        if(Mathf.Abs (rb2d.velocity.x) > maxSpeed)
        {
            //Which Direction and * by Max Speed in that Direction at Max Speed
            rb2d.velocity = new Vector2(Mathf.Sign(rb2d.velocity.x) * maxSpeed, rb2d.velocity.y); //Mathf.Sign returns 1 if postive # or -1 if negative #
        }

        //Fliping the Player based on what Direction Moving
        if( h > 0 && !faceingRight)
        {
            Flip();
        }
        else if (h < 0 && faceingRight)
        {
            Flip();
        }

        if (jump)
        {
            anim.SetTrigger("Jump");
            rb2d.AddForce(new Vector2(0f, jumpForce));
            jump = false;
        }
    }

    //Rotates Player Around After Jump
    void Flip()
    {
        faceingRight = !faceingRight;
        Vector3 theScale = transform.localScale; //Stores the Scale in theScale
        theScale.x *= -1;                       //Scaling by -1 will flip the Player Around
        transform.localScale = theScale;
    }

}
