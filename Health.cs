using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public bool dead = false;

    public float health=0.0f;
    public float initialHealth = 100.0f;

    public void takeDamage(float amount)
    {
        if((this.health-amount)<=0.0f){
            health = 0;
        }else{
            health -= amount;
        }
       
    }

    public bool isDead()
    {
        if (this.health <= 0)
        {
            return true;
        }
        return false;
    }

    void Awake()
    {
        health = initialHealth;
    }

}
