using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyMe : MonoBehaviour                                                                  //This script is mostly not own code and it is from the video tutorials where we learned from
                                                                                                        //Video source: https://www.youtube.com/playlist?list=PL2cNFQAw_ndyKRiobQ2WqVBBBSbAYBobf
{
    public float aliveTime;
    // Start is called before the first frame update
    void Awake()
    {
        Destroy(gameObject, aliveTime); //this function is used to destroy components in this case we want our game object (projectile) to be destroyed
    }

    // Update is called once per frame
    void Update()
    {

    }
}
