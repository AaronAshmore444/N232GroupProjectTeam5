using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    [Header("Health Settings")]
    public int maxHealth = 100;
    public int currentHealth;
    [Header("Poison Settings")]
    public ParticleSystem poisonEffect; // Assign in Inspector
    private bool isPoisoned = false;
    private float poisonTimer = 0f;
    private float poisonTickTimer = 0f;
    private int poisonDamagePerTick = 5;
    private float poisonTickRate = 1f;

    [Header("UI")]
    public TextMeshProUGUI healthText; // Assign in Inspector

    void Start()
    {
        // Initialize health
        currentHealth = maxHealth;
        UpdateHealthUI();
    }
    void Update()
    {
        // Handle poison effect
        if (isPoisoned)
        {
            poisonTimer -= Time.deltaTime;
            poisonTickTimer += Time.deltaTime;
            if (poisonTickTimer >= poisonTickRate)
            {
                TakeDamage(poisonDamagePerTick);
                Debug.Log("Poison damage applied:" + poisonDamagePerTick + ". Current health: " + currentHealth);
                poisonTickTimer = 0f;
            }
            if (poisonTimer <= 0f)
            {
                isPoisoned = false;
                poisonTickTimer = 0f;
                if (poisonEffect != null)
                {
                    poisonEffect.Stop();
                }
                Debug.Log("Poison effect ended.");
            }
        }
    }

    

    // Method to take damage
    public void TakeDamage(int amount)
    {
        Debug.Log("TakeDamage called. Amount: " + amount + " Current Health Before: " + currentHealth);
        if (amount < 0) return; // Prevent negative damage
        currentHealth -= amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        UpdateHealthUI();

        if (currentHealth <= 0)
        {
            Die();
        }
    }
    // Method to apply poison effect
    public void ApplyPoison(int damagePerSecond, float duration)
    {
        if (isPoisoned)
        return;
        
        isPoisoned = true;
        poisonDamagePerTick = damagePerSecond;
        poisonTimer = duration;
        poisonTickTimer = 0f;
        if (poisonEffect != null)
        {
            poisonEffect.Play();
        }
        Debug.Log("Player poisoned for " + duration + " seconds with " + damagePerSecond);
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
        gameObject.SetActive(false);
        // Add death logic here (respawn, game over, etc.)
    }
}
