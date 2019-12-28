using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashHit : MonoBehaviour                        //This script is not own code and it is from the video tutorial's where we learned from
                                                              //Video source: https://www.youtube.com/playlist?list=PL2cNFQAw_ndyKRiobQ2WqVBBBSbAYBobf
{
    public float weaponDamage;
    ProjectileController myPC;
    // Start is called before the first frame update
    void Awake()
    {
        myPC = GetComponentInParent<ProjectileController>(); //this is in the parent component in unity related to our missile and try to find the projectileController
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other) //this is going to be for whenever the collider on our missile has a collision with another collider that other collider will show up here
    {
        if (other.gameObject.CompareTag("Player"))
        {
            HealthSystem hurtEnemy = other.gameObject.GetComponent<HealthSystem>();
            hurtEnemy.PlayerDamage(weaponDamage);
            myPC.removeForce();
            Destroy(gameObject);
        }
    }

    void OnTriggerStay2D(Collider2D other) //this is to make sure if the rocket is going super fast we can still catch it
    {
        if (other.gameObject.CompareTag("Player"))
        {
            HealthSystem hurtEnemy = other.gameObject.GetComponent<HealthSystem>();
            hurtEnemy.PlayerDamage(weaponDamage);
            myPC.removeForce();
            Destroy(gameObject);
        }
    }
}