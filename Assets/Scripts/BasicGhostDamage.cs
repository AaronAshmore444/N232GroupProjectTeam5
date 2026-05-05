using UnityEngine;

public class BasicGhostDamage : MonoBehaviour //
{
    public int damageAmount = 3; // Amount of damage the ghost will deal to the player
    public float damageCooldown = 1.5f; // Cooldown time in seconds between damage applications

    private static float globalLastDamageTime = 0f; // Static variable to track the last time any ghost dealt damage

    private void OnTriggerStay(Collider other) // Use OnTriggerStay to continuously check for damage
    {
        if (!other.CompareTag("Player")) // Only damage the player
            return;

        if (Time.time < globalLastDamageTime + damageCooldown) // Check if cooldown has passed
            return;

        PlayerHealth playerHealth = other.GetComponent<PlayerHealth>(); // Get PlayerHealth from parent to ensure we get the correct component

        if (playerHealth != null) // If the player has a PlayerHealth component, apply damage
        {
            playerHealth.TakeDamage(damageAmount); //  Apply damage to the player
            Debug.Log("Player took damage from: " + gameObject.name); // Log the damage event with the name of the ghost
            globalLastDamageTime = Time.time; // Update the global last damage time to enforce cooldown across all ghosts
        }
    }
}