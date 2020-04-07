using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Variables
    public float maxHealth, maxThirst, maxHunger;
    public float thirstIncreaseRate, hungerIncreaseRate;
    private float health, thirst, hunger;

    public bool playerDeath;

    // Functions
    public void Start()
    {
        health = maxHealth;
    }

    public void Update()
    {
        // thirst and hunger increase
        if (!playerDeath)
        {
            thirst += thirstIncreaseRate * Time.deltaTime;
            hunger += hungerIncreaseRate * Time.deltaTime;
        }
        if (thirst >= maxThirst || hunger >= maxHunger)
        {
            //Die();
        }
    }

    public void Die()
    {
        playerDeath = true;
        print("Player has died of " + "Insert death source");
    }

    public void Drink(float decreaseRate)
    {
        thirst -= decreaseRate;
    }
}
