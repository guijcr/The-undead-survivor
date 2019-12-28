using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthSystem : MonoBehaviour               //This script is own code and it is has the whole health system for the our main character
{
    public Slider healthBar;
    public GameObject jumpScare;
    public GameObject brain;
    public GameObject bossEyes;
    float timer = 0f;
    // Start is called before the first frame update
    void Start()
    {
        healthBar.value = 100;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (healthBar.value == 0) 
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);      //Restarting the level when the main character dies
        }
        else if(SceneManager.GetActiveScene().name == "1stLevel" && transform.position.y < -17.9f) SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);        //death in level 1
        else if (SceneManager.GetActiveScene().name == "finalLevel" && transform.position.y < -40f) SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);       //death in final level
    }

    private void OnCollisionEnter2D(Collision2D collision)             
    {
        if (collision.gameObject.tag == "Enemies" && timer > 2.0f)  //Damage setup for the enemies (BOSS);
        {
            timer = 0;
            healthBar.value -= 30;
            gameObject.GetComponent<AudioSource>().Play();
        }
        else if (collision.gameObject.tag == "Food")                //Healing setup for the food;    
        {
            healthBar.value += 15;
            brain.GetComponent<AudioSource>().Play();
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.tag == "trapBait")            //Destroying the trap baits;
        {
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "scareTrap")                //JumpScare setup;
        {
            jumpScare.GetComponent<AudioSource>().Play();
        }
    }
    private void OnTriggerStay2D(Collider2D collision)            
    {
        if (collision.gameObject.tag == "Lava" && timer > 2.0f) //Damage setup for the lava
        {
            timer = 0;
            healthBar.value -= 25;
            gameObject.GetComponent<AudioSource>().Play();
        }

        if (collision.gameObject.tag == "trap" && timer > 2.0f) //Damage setup for the traps
        {
            timer = 0;
            healthBar.value -= 15;
            gameObject.GetComponent<AudioSource>().Play();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)        //Setup for eyes and text pop-up in the final level
    {
        if (collision.gameObject.tag == "eyes")
        {
            bossEyes.SetActive(true);
        }
    }

    public void PlayerDamage(float damage)                  //This function is called when the main character is hit by one of the projectile's from the boss
    {
        healthBar.value -= damage;
    }

}
