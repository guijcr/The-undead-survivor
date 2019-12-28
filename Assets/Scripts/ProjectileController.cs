using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour                                                                               //This script is partly based on the shooting system from the tutorials and partly own code
                                                                                                                                //Video Source: https://www.youtube.com/playlist?list=PL2cNFQAw_ndyKRiobQ2WqVBBBSbAYBobf
{
    public float rocketSpeed;
    Rigidbody2D myRB; //this is a reference to the rigidbody to the existing object wherever the script is

    // Start is called before the first frame update
    void Awake() //awake occurs when the object first comes to life
    {
        myRB = GetComponent<Rigidbody2D>();

        if (transform.localRotation.z > 0) //if there is rotation on the Z axis
        {
            //apply a force to this rigidbody (burst effect using impulse force to shoot of the rocket in a direction)
            myRB.AddForce(new Vector2(-1, 0) * rocketSpeed, ForceMode2D.Impulse);
        }
        else
        {
            myRB.AddForce(new Vector2(1, 0) * rocketSpeed, ForceMode2D.Impulse);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void removeForce() //if this function is called I want this object to stop completely. This is called when the projectile hits the enemy layer in the rocket hit script
    {
        myRB.velocity = new Vector2(0, 0); //we set the velocity of our rigidBody to zero so it stops immediatelly
    }
}
