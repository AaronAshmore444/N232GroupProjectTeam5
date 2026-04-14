using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    [Header("Health Settings")]
    public int maxHealth = 100;
    public int currentHealth;

    [Header("UI")]
    public TextMeshProUGUI healthText; // Assign in Inspector

    void Start()
    {
        // Initialize health
        currentHealth = maxHealth;
        UpdateHealthUI();
    }

    // Method to take damage
    public void TakeDamage(int amount)
    {
        if (amount < 0) return; // Prevent negative damage
        currentHealth -= amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        UpdateHealthUI();

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    // Method to heal
    public void Heal(int amount)
    {
        if (amount < 0) return; // Prevent negative healing
        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        UpdateHealthUI();
    }

    // Update TMP UI
    private void UpdateHealthUI()
    {
        if (healthText != null)
        {
            healthText.text = $"Health: {currentHealth}/{maxHealth}";
        }
    }

    // Handle player death
    private void Die()
    {
        Debug.Log("Player has died!");
        // Add death logic here (respawn, game over, etc.)
    }
}
