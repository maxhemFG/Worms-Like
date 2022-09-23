using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float maxHealth = 100f;
    private float currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    private void Update()
    {
        if(currentHealth <= 0)
        {
            Debug.Log(gameObject.transform.name);
        }
    }

    public void ApplyDamage(float damageAmount)
    {
        currentHealth -= damageAmount;
    }


}
