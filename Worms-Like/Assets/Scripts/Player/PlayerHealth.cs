using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    PlayerUnit unit;
    [SerializeField] private float maxHealth = 100f;
    private float currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
        unit = GetComponent<PlayerUnit>();
    }

    private void Update()
    {
        if(currentHealth <= 0)
        {
            Debug.Log(gameObject.transform.name);
            OnDeath();
        }
    }

    public void ApplyDamage(float damageAmount)
    {
        currentHealth -= damageAmount;
    }

    private void OnDeath()
    {
        PlayerUnitManager.UnitDeath(unit.GetID());
    }


}
