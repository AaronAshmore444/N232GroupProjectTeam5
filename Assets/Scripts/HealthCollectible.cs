using UnityEngine;

public class HealthCollectible : MonoBehaviour
{
    public int healAmount = 20; // Amount to heal

    private void OnTriggerEnter(Collider other)
    {
        // Check if the object has a PlayerHealth component
        PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            playerHealth.Heal(healAmount);
            Destroy(gameObject); // Remove collectible after pickup
        }
    }
}
