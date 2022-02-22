using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvilUp : MonoBehaviour
{
    public GameObject PickupEffect;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            EvilPowerUp(other);

        }
    }

    void EvilPowerUp(Collider Player)
    {
        Instantiate(PickupEffect, transform.position, transform.rotation);
        Stamina.instance.PickEvilPowerUps(15);

        Debug.Log("hit");
        Destroy(gameObject);
    }
}
