using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesFalling : MonoBehaviour                                 //This script is own code based on some research online except for the lines 28 and 29
{
    public float fallSpeed = 6f;          //falling speed
    public float spinSpeed = 250f;        //spinning speed
    public GameObject player;             //player's game object
    float positiondiff;
    float absoluteValue;
    bool fall = false;
    float timer = 0f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()                                                         //in this update function we compare the players position with the falling object position and the falling is only triggered when the player's x axis is
    //in a range of less than 6f, after the object starts falling it cannot stop, we also have an extra check so that the falling can only start 5 seconds after the game started
    {
        timer += Time.time;
        positiondiff = player.transform.position.x - transform.position.x;
        absoluteValue = Mathf.Abs(positiondiff);
        if ((absoluteValue < 6 || fall == true) && timer > 5f) {
            fall = true;
            transform.Translate(Vector3.down * fallSpeed * Time.deltaTime, Space.World);  //translation (settinp up the falling) for the gameObject 
            transform.Rotate(Vector3.back, spinSpeed * Time.deltaTime);                   //rotation for the gameObject
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)                            //in this function we destroy the falling gameObject if it collides with the ground layer
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            Destroy(gameObject);
        }
    }
}
