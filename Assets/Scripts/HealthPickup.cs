using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    public GameObject pickupEffect;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Pickup(other);
        }
    }

    void Pickup(Collider player)
    {
        HealthPoints stats = player.GetComponent<HealthPoints>();
        stats.CurrentHealth += 25;

        Destroy(gameObject);
    }
}
