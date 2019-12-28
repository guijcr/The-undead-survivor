using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealth : MonoBehaviour                             //This script is own code
{
    public float enemyMaxHealth;
    public Slider enemySlider;
    public GameObject winCondition;
    public GameObject mainCamera;
    float currentHealth;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = enemyMaxHealth;
        enemySlider.maxValue = enemyMaxHealth;
        enemySlider.value = currentHealth;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddDamage(float damage)
    {
        enemySlider.gameObject.SetActive(true);
        currentHealth -= damage;
        //next lines will be for the enemy health bar
        enemySlider.value = currentHealth;
        if (currentHealth <= 0) MakeDead(); //if our current health is less than or equal to zero call the function to delete our object
    }

    void MakeDead()
    {                                                          //Destroy the boss when he dies and change the music to a happier success music for defeating him
        winCondition.SetActive(true);
        mainCamera.GetComponent<AudioSource>().Stop();
        winCondition.GetComponent<AudioSource>().Play();
        Destroy(gameObject);
    }
}
