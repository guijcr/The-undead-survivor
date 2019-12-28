using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nextLvlTrigger : MonoBehaviour                              //This script is own code
                                                                         //This script is located at the portal's at the end of which level
{
    bool nextlvl = false;
    public GameObject gameManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()                           //This function activates the script "SceneChanges" for the gameObject in cause
    {
        if(nextlvl)gameManager.GetComponent<SceneChanges>().enabled = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)      //if our player collides with this script's gameObject nextlvl becomes true which will trigger the if statement in the update function
    {
        if (collision.gameObject.tag == "Player")
        {
            nextlvl = true;
        }
    }
}
