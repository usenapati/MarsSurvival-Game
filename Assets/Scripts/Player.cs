using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Variables
    public float maxHealth, maxThirst, maxHunger, maxOxygen;
    public float thirstIncreaseRate, hungerIncreaseRate, oxygenIncreaseRate, oxygenDecreaseRate;
    private float health, thirst, hunger, oxygen;
    private string causeOfDeath;

    public bool playerDeath;
    public PlayerMovement pm;
    public MouseLook ml;

    // Functions
    public void Start()
    {
        health = maxHealth;
        oxygen = maxOxygen;
    }

    public void Update()
    {
        // thirst and hunger increase
        if (!playerDeath)
        {
            thirst += thirstIncreaseRate * Time.deltaTime;
            hunger += hungerIncreaseRate * Time.deltaTime;
            if ((this.transform.position.x > 6 || this.transform.position.x < -16) || 
                (this.transform.position.y > 12 || this.transform.position.y < 1) || 
                (this.transform.position.z > 16 || this.transform.position.z < -21))
            {
                oxygen -= oxygenDecreaseRate * Time.deltaTime;
            } else
            {
                oxygen += oxygenIncreaseRate * Time.deltaTime;
            }
        }
        if (hunger >= maxHunger)
        {
            health--;
            causeOfDeath = "lack of food.";
        }
        else if (thirst >= maxThirst)
        {
            health--;
            causeOfDeath = "lack of water.";
        }
        else if (oxygen <= 0)
        {
            health--;
            causeOfDeath = "lack of oxygen.";
        }
        if (health <= 0)
        {
            Die(causeOfDeath);
        }
    }

    public void Die(string deathSource)
    {
        playerDeath = true;
        print("Player has died of " + deathSource);
        pm.enabled = false;
        ml.enabled = false;
    }

    public void Drink(float decreaseRate)
    {
        thirst -= decreaseRate;
    }
}
