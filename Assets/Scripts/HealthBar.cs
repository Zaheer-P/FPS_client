using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider healthBar;
    public float playerHealth;
    public float maxHealth;
    public GameObject Player;
    

    private void Start()
    {
        //playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>().health;
        maxHealth = 100f;
        healthBar = GetComponent<Slider>();
        healthBar.maxValue = maxHealth;
        
        //Player = GameObject.FindGameObjectWithTag("Player");
    }

    public void Update()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        if (Player != null)
        {
            Debug.Log("not null");

            playerHealth = Player.GetComponent<PlayerManager>().health;
            healthBar.value = playerHealth;
        }
        
        Debug.Log(Player);
        
    }
}