using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKillZ : MonoBehaviour
{
    [SerializeField] private float killDamage = 1000f; 
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.GetComponent<PlayerHealth>())
        {
            other.gameObject.GetComponent<PlayerHealth>().ApplyDamage(killDamage);
        }    

    }

}
