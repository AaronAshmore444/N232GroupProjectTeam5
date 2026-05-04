using UnityEngine;

public class HealthPoints : MonoBehaviour
{
    public float StartingHealth = 100f;

    public float CurrentHealth

    {
        get { return _HealthPoints; }
        set
        {
            _HealthPoints = Mathf.Clamp(value, 0, StartingHealth);

            if (_HealthPoints <= 0)
            {
                Die();
            }
        }
    }

    private float _HealthPoints;
    public void TakeDamage(float amount)
    {
        CurrentHealth -= amount;
        Debug.Log("Health: " + CurrentHealth);
    }
    void Start()
    {
        CurrentHealth = StartingHealth;
        
    }

    void Die()
    {
        Destroy(gameObject);
        Debug.Log("Player Died");
    }
}