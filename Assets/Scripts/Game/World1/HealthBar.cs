using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public float health;
    float maxHealth = 1.0f;
    float minHealth = 0.0f;
    public float damage = 0.1f;
    private Slider healthBar;

    private void Awake()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        healthBar = GetComponentInChildren<Slider>();
        healthBar.minValue = minHealth;
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        health = healthBar.value;
    }

    public void DeductHealth()
    {
        healthBar.value -= damage;
    }
}
