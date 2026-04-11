using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int pointsValue = 10; // Points awarded for this enemy
    private GameManager gameManager;

    // Initialization
    void Start()
    {
        // Find the GameManager in the scene
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Example method to simulate taking damage
    public void TakeDamage(int damage)
    {
        // For simplicity, we destroy the enemy when any damage is taken
        Die();
    }

    // Handle enemy death
    void Die()
    {
        if (gameManager != null)
        {
            gameManager.AddPoints(pointsValue);
        }
        Destroy(gameObject);
    }
}

