using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour                                                                         //This script is mostly not own code and it is from the video tutorials where we learned from
                                                                                                                    //Video source: https://www.youtube.com/playlist?list=PL2cNFQAw_ndyKRiobQ2WqVBBBSbAYBobf
                                                                                                                    //The lines that are own code go from line 102 to 108
{
    // Start is called before the first frame update
    public float maxSpeed;

    //Jumping variables
    bool grounded = false; //this variable will be used to transfer back and forward in the jumpblendtree in the animation
    float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;
    public Transform groundCheck;
    public float jumpHeight;
    public float trampolineForce = 2f;

    Rigidbody2D myRB;
    Animator myAnim;
    bool facingRight;

    //For shooting
    public Transform gunTip;
    public GameObject brainBullet; //this will be the reference for the projectile
    float fireRate = 0.5f; //this will mean the character will be able to shoot one rocket every half a second
    float nextFire = 0f;   //will be able to fire immediatelly
    void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();

        facingRight = true;
    }


    void Update()
    {
        if (grounded && Input.GetKeyDown(KeyCode.Space))    //if we are not on the floor and our Jump axis is greater than zero we get in the loop
        {                                                   //change the values in our animator for the variables grounded and isGrounded
            grounded = false;
            myAnim.SetBool("isGrounded", grounded);
            myRB.velocity = Vector2.up * jumpHeight;
        }

        //player shooting
        if (Input.GetAxisRaw("Fire1") > 0) FireBrains();//getaxisraw only takes values of -1,0 or 1. Fire1 is correspondent to the left mouse button in unity
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Check if we are grounded -> if no then we are falling
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer); //this is going to draw a tiny circle in the groundCheck 
        //position with the size we give it and in the layer we give it. After this it will check if we intersect with anything. So if intersecting with the ground
        //it will give a true value if not it will be false
        myAnim.SetBool("isGrounded", grounded);
        myAnim.SetFloat("verticalSpeed", myRB.velocity.y); //changing our vertical speed to our rigib body velocity in the Y axis
        //print("VERTICAL SPEEED" + myAnim.GetFloat("verticalSpeed"));

        float move = Input.GetAxis("Horizontal");   //Checking if the player is pushing a button in the horizontal axis of unity and save this value //Get axis returns a value between -1 and 1. Axis is a predefined value in the unity. Edit -> Project Settings Input
        myAnim.SetFloat("speed", Mathf.Abs(move)); //This is going to return a value between 0 and 1

        myRB.velocity = new Vector2(move * maxSpeed, myRB.velocity.y); //here we only change the velocity value of the X axis and we keep the Y one       //vector2 it means it is a 2D vector
        //print("VELOCITY" + myRB.velocity);
        if (move > 0 && !facingRight)  //if player is pressing the A key and is facing left flip it around
        {
            Flip();
        }
        else if (move < 0 && facingRight)   //if player is pressing the D key and is facing left flip it around
        {
            Flip();
        }
    }

    void Flip() //function to make the character face the other way
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale; //taking the values from the character scale. We use a 3D vector because the scale has X,Y and Z
        theScale.x *= -1;   //multiply the X of the scale by -1 to flip the character the other way
        transform.localScale = theScale;
    }

    void FireBrains()
    {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate; //next fire will be equal to the current time plus the time for the next shot
            if (facingRight)
            {
                Instantiate(brainBullet, gunTip.position, Quaternion.Euler(new Vector3(0, 0, 0)));
            }
            //instantiate variables: what we are going to instantiate, where we gonna instantiate it, the rotation of the object being instantiated
            else if (!facingRight) //if our character is facing left we flip the location of the rocket to the left side
            {
                Instantiate(brainBullet, gunTip.position, Quaternion.Euler(new Vector3(0, 0, 180f)));
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Trampoline")
        {
            myRB.velocity = Vector2.up * jumpHeight * trampolineForce;
        }
    }

}
