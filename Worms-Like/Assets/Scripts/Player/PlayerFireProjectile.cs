using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFireProjectile : MonoBehaviour
{
    [Header("Weapon Attributes")]
    [SerializeField] private float timeBetweenShots = 0.2f;
    [SerializeField] private float projectileSpeed = 25f;
    [SerializeField] private float projectileDamage = 50f;
    [Tooltip("The impulse which launches the player backwards when shooting while in air.")]
    [SerializeField] private float recoilImpulse = 15f;
    private float timerFireRate = 0f;

    [Header("Required GameObjects")]
    [SerializeField] private Rigidbody unitRigidbody;
    [SerializeField] private Transform gunBarrel;
    [SerializeField] private GameObject projectile;
    
    private void Start()
    {
        timerFireRate = timeBetweenShots;
    }

    private void Update()
    {
        timerFireRate += Time.deltaTime;
    }

    public void Shoot(bool grounded)
    {

        if (timerFireRate >= timeBetweenShots)
        {
            GameObject clone = Instantiate(projectile, gunBarrel.position, Quaternion.identity);
            clone.transform.rotation = gunBarrel.rotation;
            Projectile cloneBehavior = clone.gameObject.GetComponent<Projectile>();
            cloneBehavior.SetProjectileImpulse(projectileSpeed);
            cloneBehavior.SetDamage(projectileDamage);
            
            if(TurnManager.GetCurrentPlayer() == 1)
            {
                cloneBehavior.SetEnemy("TeamRed");
            }
            else
            {
                cloneBehavior.SetEnemy("TeamBlue");
            }

            Destroy(clone, 5f);
            timerFireRate = 0f;

            if (!grounded)
            {
                unitRigidbody.AddForce(-transform.forward * recoilImpulse, ForceMode.Impulse);
            }
        }

       
    }
}
