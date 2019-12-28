using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothJump : MonoBehaviour                  //This script is not own code and it is based on some research
                                                         //link for the source: Video Title "Better Jumping in Unity With Four Lines of Code": https://youtu.be/7KiK0Aqtmzc?t=733
{
    public float fallSpeed;
    public float lowJumpForce;

    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * fallSpeed * Time.deltaTime;
        } else if (rb.velocity.y > 0) {
            rb.velocity += Vector2.up * Physics2D.gravity.y * lowJumpForce * Time.deltaTime;
        }
    }
}
