using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanges : MonoBehaviour                                                                                   //This script is own code based on some online research
{
    float timer = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.time;
            if (SceneManager.GetActiveScene().name == "1stLevel") SceneManager.LoadScene(sceneName: "2ndLevel");
            else if (SceneManager.GetActiveScene().name == "2ndLevel") SceneManager.LoadScene(sceneName: "finalLevel");
    }
}
