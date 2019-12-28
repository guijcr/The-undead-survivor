using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateFalling : MonoBehaviour                 //This is own code and it is a simple script located in the gameManager gameObject to activate the parent gameObject for the falling enemies
{
    public GameObject fallingobjects;               
    // Start is called before the first frame update
    void Start()
    {
        fallingobjects.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
