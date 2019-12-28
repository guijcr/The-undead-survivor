using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDamage : MonoBehaviour                                                                                        //This script is partly based on the shooting system from the tutorials and partly own code
                                                                                                                               //Video Source: https://www.youtube.com/playlist?list=PL2cNFQAw_ndyKRiobQ2WqVBBBSbAYBobf
                                                                                                                               //The own code lines go from line 28 to 41
{
    public Transform gunTip;
    public Transform player;
    public GameObject brainBullet; //this will be the reference for the projectile
    float fireRate = 1f; //this will mean the boss will be able to shoot one splash every half a second
    float nextFire = 0f;   //will be able to fire immediatelly
    Vector3 targetCamPos;
    float offset;
    float startY;
    float nexty;
    float smoothing = 100f;  //this is used to speed up the velocity that the boss transform position updates to be the same in the y axis as our main character transform position

    // Start is called before the first frame update
    void Start()
    {
        startY = player.position.y;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        nexty = player.position.y;
        //This if statements are for the boss to follow you around in the y axis while he is shootting at you
        if (nexty > startY) {
            offset = nexty - startY;
            targetCamPos = new Vector3(transform.position.x, transform.position.y + offset, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.fixedDeltaTime);
        }
        else if (nexty < startY) {
            offset = startY - nexty;
            targetCamPos = new Vector3(transform.position.x, transform.position.y - offset, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.fixedDeltaTime);
        }
        startY = nexty;
        //trigger boss shooting function
        FireBrains();
    }

    void FireBrains()
    {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate; //next fire will be equal to the current time plus the time for the next shot
            Instantiate(brainBullet, gunTip.position, Quaternion.Euler(new Vector3(0, 0, 180f)));
        }
    }
}
