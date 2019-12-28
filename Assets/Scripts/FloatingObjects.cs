using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingObjects : MonoBehaviour                //This script in own code based on some online research
{
    public float floatingSpd = 3f;
    Vector3 origin;
    void Start()
    {
        origin = transform.position;
    }

    private void Update()
    {
        Vector3 pos = transform.position;
        float newY = Mathf.Sin(Time.time * floatingSpd) + origin.y;
        pos.y = newY;
        transform.position = pos;
    }
}


