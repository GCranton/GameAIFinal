using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityStats : MonoBehaviour
{
    public int maxHealth = 100;
    public int health;
    public int healthRegen;
    public float regenTime;
    public float regenInterval = 1.0f;
    public float moveSpeed;
    public float horizontalLookSpeed;
    public float verticalLookSpeed;

    private float timeSinceDamage;
    private float timeSinceRegen;

    void Start(){
        health = maxHealth;
    }

    void Update(){
        timeSinceDamage += Time.deltaTime;
        timeSinceRegen += Time.deltaTime;
        if(timeSinceDamage >= regenTime && timeSinceRegen >= regenInterval){
            Heal(healthRegen);
            timeSinceRegen = 0;
        }
    }

    public void Damage(int dmg){
        health -= dmg;
        timeSinceDamage = 0;
    }

    void Heal(int amt){
        health += amt;
        if(health > maxHealth){
            health = maxHealth;
        }
    }
}
