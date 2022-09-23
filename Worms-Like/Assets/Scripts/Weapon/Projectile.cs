using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    Rigidbody unitRigidBody;
    private float damage = 50f;
    private float projectileImpulse = 30f;
    private string enemyTeam;

    private void Start()
    {
        unitRigidBody = GetComponent<Rigidbody>();
        unitRigidBody.AddForce(transform.forward * projectileImpulse, ForceMode.VelocityChange);        
    }

    public void SetProjectileImpulse(float impulse)
    {
        projectileImpulse = impulse;
    }

    public void SetDamage(float projectileDamage)
    {
        damage = projectileDamage;
    }

    public void SetEnemy(string tag)
    {
        enemyTeam = tag;
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.collider.CompareTag(enemyTeam))
        {
            collision.gameObject.GetComponent<PlayerHealth>().ApplyDamage(damage);
        }

        Destroy(gameObject);
    }
}
