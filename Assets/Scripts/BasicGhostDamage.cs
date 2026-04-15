using UnityEngine;

public class BasicGhostDamage : MonoBehaviour
{
    public int damageAmount = 10;
    public float damageCooldown = 1f;
    private float lastDamageTime = 0f;

    private void OnTriggerStay(Collider other)
    {
        // Only proceed if the object is the player
        if (!other.CompareTag("Player"))
            return;

        // Get the PlayerHealth component (use InParent in case of child colliders)
        HealthPoints playerHealth = other.GetComponentInParent<HealthPoints>();

        if (playerHealth != null)
        {
            // Apply damage with a cooldown
            if (Time.time >= lastDamageTime + damageCooldown)
            {
                playerHealth.TakeDamage(damageAmount);
                Debug.Log("Player took damage: " + damageAmount);
                lastDamageTime = Time.time;
            }
        }
        else
        {
            Debug.LogWarning("PlayerHealth component not found on the player.");
        }
    }
}