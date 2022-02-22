using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public GameObject pickupEffect;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Pickup(other);

        }
    }

    void Pickup(Collider Player)
    {
        Instantiate(pickupEffect, transform.position, transform.rotation);
        Stamina.instance.PickPowerUps(20);
        Destroy(gameObject);
    }
}
