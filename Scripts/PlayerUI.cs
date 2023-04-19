using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    public Slider healthBar;
    public Text ammoCount;
    public EntityStats playerStats;
    public Gun playerGun;

    void Start(){
        if(playerStats == null){
            playerStats = GetComponent<EntityStats>();
        }
        healthBar.maxValue = playerStats.maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.value = playerStats.health;
        ammoCount.text = "" + playerGun.GetAmmo() + "/" + playerGun.maxAmmo;
    }
}
