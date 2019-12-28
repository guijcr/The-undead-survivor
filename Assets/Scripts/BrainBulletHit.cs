using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrainBulletHit : MonoBehaviour                        //This script is not own code and it is from the video tutorials where we learned from
                                                                   //Video source: https://www.youtube.com/playlist?list=PL2cNFQAw_ndyKRiobQ2WqVBBBSbAYBobf
{

    public float weaponDamage;
    ProjectileController myPC; //reference to the projectile controller script on the parent object which is the projectile in this prefab since this is script is in the missile
    // Start is called before the first frame update
    void Awake()
    {
        myPC = GetComponentInParent<ProjectileController>(); //this is in the parent component in unity related to our missile and try to find the projectileController
        //we can now access the projectilecontroller script
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other) //this is going to be for whenever the collider on our missile has a collision with another collider that other collider will show up here
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Shootable")) //if the other layer object is equal to our shooter layer then something will happen
        {
            myPC.removeForce(); //this will call the function in the projectileController script that it is used to stop the projectile
            Destroy(gameObject); //this will only destroy the missile and not the projectile. this also makes sure that the smoke stays in place
            if (other.CompareTag("Enemies"))
            {
                BossHealth hurtEnemy = other.gameObject.GetComponent<BossHealth>();
                hurtEnemy.AddDamage(weaponDamage);
            }
        }
    }

    void OnTriggerStay2D(Collider2D other) //this is to make sure if the rocket is going super fast we can still catch it
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Shootable")) //if the other layer object is equal to our shooter layer then something will happen
        {

            myPC.removeForce(); //this will call the function in the projectileController script that it is used to stop the projectile
            Destroy(gameObject); //this will only destroy the missile and not the projectile. this also makes sure that the smoke stays in place
            if (other.CompareTag("Enemies"))
            {
                BossHealth hurtEnemy = other.gameObject.GetComponent<BossHealth>();
                hurtEnemy.AddDamage(weaponDamage);
            }
        }
    }
}
