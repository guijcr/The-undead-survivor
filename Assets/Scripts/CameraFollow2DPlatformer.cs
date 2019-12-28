using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow2DPlatformer : MonoBehaviour                                                                           //This script is mostly not own code and it is from the video tutorials where we learned from
                                                                                                                                //Video source: https://www.youtube.com/playlist?list=PL2cNFQAw_ndyKRiobQ2WqVBBBSbAYBobf
                                                                                                                                //The line 17 and 33 is own code
{

    public Transform target; //what the camera is following (which will be the character's transform)
    public float smoothing;
    Vector3 targetCamPos;
    Vector3 offset;

    float lowY; //this will be the lowest point our camera can go so that when our character falls off the screen the character does not follow
                // Start is called before the first frame update
    readonly float maxX = 40f;
    void Start()
    {
        offset = transform.position - target.position;

        lowY = transform.position.y - 20f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        targetCamPos = target.position + offset;

        transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime); //Time.deltaTime is the time in seconds it took to complete the last frame
        //we will move the camera position from the transform to the targetCamPos and it will slow down as closer as it gets with a speed of smoothing*Time.deltaTime
        if (transform.position.y < lowY) transform.position = new Vector3(transform.position.x, lowY, transform.position.z);
        else if (transform.position.x > maxX) transform.position = new Vector3(maxX, transform.position.y, transform.position.z);
    }
}
